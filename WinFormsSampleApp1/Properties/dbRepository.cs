using System;
using System.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using WinFormsSampleApp1.Properties.Models;
using BCrypt.Net;

namespace WinFormsSampleApp1.Properties
{
    public class dbRepository
    {
        // Define the connection string
        private string ConnectionString = "Server=127.0.0.1;Port=3306;Database=RentaHALL2;Uid=root;Pwd=Eric@tripulca.com;";
        private string _currentEmployeeEmail; // Track logged-in employee

        // Method to test the database connection
        public bool TestConnection()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open(); // Attempt to open the connection
                    Console.WriteLine("Connection successful!");
                    return true; // Return true if the connection is successful
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; // Return false if the connection fails
            }
        }

        // Example method to execute a query
        public void ExecuteQuery(string query)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open(); // Open the connection
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery(); // Execute the query
                        Console.WriteLine("Query executed successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + ex.Message);
            }
        }

        // Method to get the hashed password for an owner
        public string GetOwnerPasswordHash(string username)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT password_hash FROM owner WHERE username = @username";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        object result = cmd.ExecuteScalar();
                        return result?.ToString(); // Return the hashed password if found
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving owner password hash: " + ex.Message);
                return null;
            }
        }

        // Method to get the hashed password and role for an employee
        public (string PasswordHash, string Role, string emp_status) GetEmployeeCredentials(string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT emp_password, role, emp_status FROM employee WHERE email = @email";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve the hashed password, role, and status from the reader
                                string passwordHash = reader.GetString("emp_password");
                                string role = reader.GetString("role");
                                string emp_status = reader.GetString("emp_status");

                                // Return the hashed password, role, and status
                                return (passwordHash, role, emp_status);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving employee credentials: " + ex.Message);
            }
            return (null, null, null); // Return null if no match is found
        }

        public void UpdateEmployeeActivityLog(string employeeId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Query to update the login_time in the employee_activity_log table
                    string query = @"
                        UPDATE 
                            employee
                        SET 
                            status = 'active'
                        WHERE 
                            emp_password = @employeeId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add the employeeId parameter
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Log the result for debugging
                        Console.WriteLine($"Rows updated in employee: {rowsAffected}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating employee activity log: " + ex.Message);
            }
        }

        public void SetCurrentEmployeeEmail(string email)
        {
            _currentEmployeeEmail = email;
        }

        // Get employee name (parameterless) using the tracked email
        public string GetEmployeeName()
        {
            if (string.IsNullOrEmpty(_currentEmployeeEmail))
            {
                throw new InvalidOperationException("No employee is currently logged in.");
            }
            return GetEmployeeName(_currentEmployeeEmail);
        }

        public string GetEmployeeName(string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT full_name FROM employee WHERE email = @email";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        object result = cmd.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving employee name: " + ex.Message);
                return null;
            }
        }


        public bool IsOwnerTableEmpty()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM owner";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count == 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking owner table: " + ex.Message);
                return true; // Assume empty if error occurs
            }
        }

        // Insert a new owner into the database
        public bool InsertOwner(string username, string passwordHash)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert the owner
                        string ownerQuery = @"
                            INSERT INTO owner (username, password_hash) 
                            VALUES (@username, @passwordHash);
                            SELECT LAST_INSERT_ID();"; // Get the new owner's ID

                        int ownerId;
                        using (MySqlCommand cmd = new MySqlCommand(ownerQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                            ownerId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 2. Insert the default business
                        string businessQuery = @"
                            INSERT INTO business (owner_id, name)
                            VALUES (@ownerId, 'RentHall')";

                        using (MySqlCommand cmd = new MySqlCommand(businessQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ownerId", ownerId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error in transaction: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        // Get owner's ID by username
        public int GetOwnerId(string username)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT id FROM owner WHERE username = @username";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting owner ID: " + ex.Message);
                return -1;
            }
        }

        // Insert security and answers
        public bool InsertSecurityAnswers(int ownerId, int q1Id, string a1, int q2Id, string a2, int q3Id, string a3)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Insert all three answers in a transaction
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            InsertAnswer(conn, ownerId, q1Id, a1);
                            InsertAnswer(conn, ownerId, q2Id, a2);
                            InsertAnswer(conn, ownerId, q3Id, a3);

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving security answers: " + ex.Message);
                return false;
            }
        }

        private void InsertAnswer(MySqlConnection conn, int ownerId, int questionId, string answer)
        {
            string query = @"
            INSERT INTO owner_security_questions 
                (owner_id, question_id, answer_hash) 
            VALUES 
                (@ownerId, @questionId, @answerHash)
            ON DUPLICATE KEY UPDATE answer_hash = @answerHash";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ownerId", ownerId);
                cmd.Parameters.AddWithValue("@questionId", questionId);
                cmd.Parameters.AddWithValue("@answerHash", BCrypt.Net.BCrypt.HashPassword(answer));
                cmd.ExecuteNonQuery();
            }
        }


        // Method to fetch active rentals
        public List<ActiveRentals> GetActiveRentals()
        {
            List<ActiveRentals> activeRentals = new List<ActiveRentals>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM active_rentals";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ActiveRentals rental = new ActiveRentals
                                {
                                    RentalAgreementId = reader.GetInt32("rental_agreement_id"),
                                    TenantFullName = reader.GetString("tenant_full_name")!,
                                    TenantEmail = reader.GetString("tenant_email")!,
                                    TenantMobile = reader.GetString("tenant_mobile")!,
                                    SerialNumberId = reader.GetString("serial_number_id")!,
                                    EndDate = reader.GetDateTime("end_date")!,
                                    Duration = reader.GetString("duration")!,
                                    Status = reader.GetString("status")!,
                                    TotalAmountDue = reader.GetDecimal("total_amount_due")!,
                                    EmployeeFullName = reader.GetString("employee_full_name")!,
                                };
                                activeRentals.Add(rental);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching active rentals: " + ex.Message);
            }

            return activeRentals;
        }


        // Method to fetch total revenue from the database
        public decimal GetTotalRevenue()
        {
            decimal totalRevenue = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT SUM(total_amount) AS TotalRevenue FROM payment WHERE payment_status = 'done'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            totalRevenue = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching total revenue: " + ex.Message);
            }

            return totalRevenue;
        }


        // Method to fetch maximum revenue (sum of all fees)
        public decimal GetMaxRevenue()
        {
            decimal maxRevenue = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT SUM(amount) AS MaxRevenue FROM fee";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            maxRevenue = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching maximum revenue: " + ex.Message);
            }

            return maxRevenue;
        }

        // Method to fetch the number of employees
        public (int EmpCount, int ActCount) GetEmpNo()
        {
            int empCount = 0;
            int actCount = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Query 1: Total employee count
                    string query = "SELECT COUNT(*) AS EmpCount FROM employee WHERE emp_status = 1";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            empCount = Convert.ToInt32(result);
                        }
                    }

                    // Query 2: Active employee count
                    string query1 = "SELECT COUNT(*) AS ActCount FROM employee WHERE status = 'active'";
                    using (MySqlCommand cmd = new MySqlCommand(query1, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            actCount = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching employee count: " + ex.Message);
            }

            return (EmpCount: empCount, ActCount: actCount); // Return as a tuple
        }


        // Method to fetch the number of Tenant
        public int GetTenantNo()
        {
            int tenantCount = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) AS TenantCount FROM tenant";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            tenantCount = Convert.ToInt32(result); // Convert the result to an integer
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching employee count: " + ex.Message);
            }

            return tenantCount;
        }

        // Method to fetch the total amount due for rentals ending today
        public decimal GetDueRent()
        {
            decimal totalDueRent = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT SUM(total_amount_due) AS TotalDueRent
                FROM active_rentals
                WHERE end_date = CURDATE();";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            totalDueRent = Convert.ToDecimal(result); // Convert the result to a decimal
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching due rent: " + ex.Message);
            }

            return totalDueRent;
        }

        // Method to fetch the total overdue rent for rentals ending before the given date
        public decimal GetOverdueRent()
        {
            decimal totalOverdueRent = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT SUM(total_amount_due) AS TotalOverdueRent
                    FROM active_rentals
                    WHERE end_date < CURDATE();";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            totalOverdueRent = Convert.ToDecimal(result); // Convert the result to a decimal
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching due rent: " + ex.Message);
            }

            return totalOverdueRent;
        }

        // Method to count the number of active rentals where end_date has not passed the current date
        public int GetExp()
        {
            int expCount = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) AS ExpCount
                FROM active_rentals
                WHERE end_date >= CURDATE();";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            expCount = Convert.ToInt32(result); // Convert the result to an integer
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching expiration count: " + ex.Message);
            }

            return expCount;
        }


        // Method to count the number of active rentals where end_date has passed the current date
        public int GetExpd()
        {
            int expdCount = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) AS ExpCount
                FROM active_rentals
                WHERE end_date < CURDATE();";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            expdCount = Convert.ToInt32(result); // Convert the result to an integer
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching expiration count: " + ex.Message);
            }

            return expdCount;
        }


        // Method to count the number of unit
        public int GetUnitTotal()
        {
            int unitCount = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) AS UnitCount
                FROM inventory;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            unitCount = Convert.ToInt32(result); // Convert the result to an integer
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching unit count: " + ex.Message);
            }

            return unitCount;
        }


        // Method to count the number of rented unit
        public int GetUnitRentedTotal()
        {
            int RentedUnitCount = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) AS RentedUnitCount
                FROM inventory
                WHERE status = 'rented';";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            RentedUnitCount = Convert.ToInt32(result); // Convert the result to an integer
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching rented unit count: " + ex.Message);
            }

            return RentedUnitCount;
        }

        // Method to count the number of rented unit
        public int GetAvlUnit()
        {
            int AVLUnitCount = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(*) AS AvailableUnitCount
                FROM inventory
                WHERE status = 'available';";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            AVLUnitCount = Convert.ToInt32(result); // Convert the result to an integer
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching available rented unit count: " + ex.Message);
            }

            return AVLUnitCount;
        }

        public DataTable GetInventoryData(string searchTerm = null)
        {
            DataTable inventoryTable = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Step 1: Query the inventory table with the search term
                    string inventoryQuery = "SELECT * FROM inventory";
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        inventoryQuery += " WHERE serial_number LIKE @searchTerm OR size LIKE @searchTerm OR status LIKE @searchTerm";
                    }

                    using (MySqlCommand inventoryCmd = new MySqlCommand(inventoryQuery, conn))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            inventoryCmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(inventoryCmd))
                        {
                            adapter.Fill(inventoryTable);
                        }
                    }

                    // Step 2: If no results are found in inventory, query the product table
                    if (inventoryTable.Rows.Count == 0 && !string.IsNullOrEmpty(searchTerm))
                    {
                        string productQuery = @"
                    SELECT id 
                    FROM product 
                    WHERE name LIKE @searchTerm OR description LIKE @searchTerm OR base_price LIKE @searchTerm";

                        int? productId = null; // Nullable to handle cases where no product matches

                        using (MySqlCommand productCmd = new MySqlCommand(productQuery, conn))
                        {
                            productCmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                            object result = productCmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                            {
                                productId = Convert.ToInt32(result); // Get the product_id
                            }
                        }

                        // Step 3: Query the inventory table using the product_id
                        if (productId.HasValue)
                        {
                            string inventoryByProductQuery = @"
                        SELECT 
                            id,
                            product_id,
                            serial_number,
                            size,
                            status,
                            current_condition,
                            created_at
                        FROM 
                            inventory
                        WHERE 
                            product_id = @productId";

                            using (MySqlCommand inventoryByProductCmd = new MySqlCommand(inventoryByProductQuery, conn))
                            {
                                inventoryByProductCmd.Parameters.AddWithValue("@productId", productId.Value);

                                using (MySqlDataAdapter adapter = new MySqlDataAdapter(inventoryByProductCmd))
                                {
                                    inventoryTable.Clear(); // Clear previous data
                                    adapter.Fill(inventoryTable);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching inventory data: " + ex.Message);
            }

            return inventoryTable;
        }

        public DataTable GetProductData(string searchTerm = null)
        {
            DataTable ProductTable = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM product";
                    // Add a WHERE clause if a search term is provided
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE name LIKE @searchTerm OR description LIKE @searchTerm OR base_price LIKE @searchTerm";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(ProductTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching inventory data: " + ex.Message);
            }

            return ProductTable;
        }

        // Method to insert into product_type table
        public int InsertProductType(string typeName, string prdCode)
        {
            int productTypeId = -1;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = @"
                    INSERT INTO product_type (type_name, prd_code)
                    VALUES (@type_name, @prd_code);";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@type_name", typeName);
                        cmd.Parameters.AddWithValue("@prd_code", prdCode);
                        cmd.ExecuteNonQuery();
                    }

                    // Retrieve the last inserted ID
                    string getLastInsertIdQuery = "SELECT LAST_INSERT_ID();";
                    using (MySqlCommand lastInsertCmd = new MySqlCommand(getLastInsertIdQuery, conn))
                    {
                        productTypeId = Convert.ToInt32(lastInsertCmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting product type: " + ex.Message);
            }

            return productTypeId;
        }

        // Method to insert into product table
        public int InsertProduct(int productTypeId, string productName, string description, decimal basePrice, string priceUnit)
        {
            int product = -1;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO product (
                            business_id,
                            product_type_id,
                            name,
                            description,
                            base_price,
                            price_unit,
                            total_quantity,
                            available_quantity,
                            rented_quantity,
                            maintenance_quantity
                        )
                        VALUES (
                            1, -- business_id is hardcoded as 1
                            @product_type_id,
                            @name,
                            @description,
                            @base_price,
                            @price_unit,
                            0, -- total_quantity starts at 0
                            0, -- available_quantity starts at 0
                            0, -- rented_quantity starts at 0
                            0 -- maintenance_quantity starts at 0
                        );";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@product_type_id", productTypeId);
                        cmd.Parameters.AddWithValue("@name", productName);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@base_price", basePrice);
                        cmd.Parameters.AddWithValue("@price_unit", priceUnit);
                        cmd.ExecuteNonQuery();
                    }

                    // Retrieve the last inserted ID
                    string getLastInsertIdQuery = "SELECT LAST_INSERT_ID();";
                    using (MySqlCommand lastInsertCmd = new MySqlCommand(getLastInsertIdQuery, conn))
                    {
                        product = Convert.ToInt32(lastInsertCmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting product: " + ex.Message);
            }

            return product;
        }

        // Method to fetch all product types
        public DataTable GetProductTypes()
        {
            DataTable productTypesTable = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT type_name, prd_code FROM product_type";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(productTypesTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching product types: " + ex.Message);
            }

            return productTypesTable;
        }

        // Method to count existing serial numbers with a specific prd_code
        public int CountSerialNumbers(string prdCode)
        {
            int count = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT COUNT(*) 
                    FROM inventory 
                    WHERE serial_number LIKE @prdCodePattern";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@prdCodePattern", prdCode + "%");
                        count = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error counting serial numbers: " + ex.Message);
            }

            return count;
        }

        // Method to insert a new inventory item
        public int InsertInventoryItem(int productId, string serialNumber, string size)
        {
            int success = 1;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                    INSERT INTO inventory (product_id, serial_number, size, status, current_condition)
                    VALUES (@productId, @serialNumber, @size, 'available', 'New')";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@productId", productId);
                        cmd.Parameters.AddWithValue("@serialNumber", serialNumber);
                        cmd.Parameters.AddWithValue("@size", size);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting inventory item: " + ex.Message);
                success = -1;
            }

            return success;
        }

        // Method to generate a serial number based on prdCode
        public string GenerateSerialNumber(string prdCode)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Count the number of existing serial numbers with the given prd_code
                    string countQuery = @"
                    SELECT COUNT(*) AS count, MAX(serial_number) AS last_serial_number
                    FROM inventory
                    WHERE serial_number LIKE @prdCodePattern";

                    using (MySqlCommand countCmd = new MySqlCommand(countQuery, conn))
                    {
                        countCmd.Parameters.AddWithValue("@prdCodePattern", prdCode + "%");

                        using (MySqlDataReader reader = countCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int count = Convert.ToInt32(reader["count"]);
                                string lastSerialNumber = reader["last_serial_number"]?.ToString();

                                if (count == 0)
                                {
                                    // If no serial_numbers exist, start with "TS1001"
                                    return prdCode + "1001";
                                }
                                else
                                {
                                    // Extract the numeric part of the last serial_number
                                    string numericPart = lastSerialNumber.Substring(prdCode.Length);
                                    int numericValue = Convert.ToInt32(numericPart);

                                    // Increment the numeric part
                                    numericValue++;

                                    // Combine the prd_code with the incremented numeric part
                                    return prdCode + numericValue.ToString("D4"); // Ensure 4 digits
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating serial number: " + ex.Message);
                return null;
            }

            return null;
        }

        // Method to get product_id by prd_code
        public int GetProductIdByPrdCode(string prdCode)
        {
            int productId = -1;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT p.id 
                        FROM product_type p
                        WHERE p.prd_code = @prdCode";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@prdCode", prdCode);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            productId = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving product ID: " + ex.Message);
            }

            return productId;
        }

        public bool UpdateInventoryItem(int id, string newSize, string newStatus)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                UPDATE inventory
                SET size = @size, status = @status
                WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@size", newSize);
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if the update was successful
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating inventory item: " + ex.Message);
                return false;
            }
        }

        public bool DeleteInventoryItem(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM inventory WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if the delete was successful
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting inventory item: " + ex.Message);
                return false;
            }
        }

        public DataTable GetRentalHistory(string searchTerm = null)
        {
            DataTable rentalHistoryTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Query to fetch data from the rental_history view
                    string query = "SELECT * FROM rental_history";

                    // Add a WHERE clause if a search term is provided
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE tenant_name LIKE @searchTerm OR product_name LIKE @searchTerm OR serial_number LIKE @searchTerm";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(rentalHistoryTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching rental history data: " + ex.Message);
            }
            return rentalHistoryTable;
        }

        public DataTable GetRentalActiveRental(string searchTerm = null)
        {
            DataTable rentalActiveTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Query to fetch data from the rental_history view
                    string query = "SELECT * FROM active_rentals";

                    // Add a WHERE clause if a search term is provided
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE tenant_full_name LIKE @searchTerm OR tenant_email LIKE @searchTerm OR tenant_email LIKE @searchTerm";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(rentalActiveTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching rental history data: " + ex.Message);
            }
            return rentalActiveTable;
        }


        
        public DataTable GetRentaSummary(string searchTerm = null)
        {
            DataTable rentalActiveTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Query to fetch data from the rental_history view
                    string query = "SELECT * FROM product_rental_summary";

                    // Add a WHERE clause if a search term is provided
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE product_name LIKE @searchTerm";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(rentalActiveTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching rental history data: " + ex.Message);
            }
            return rentalActiveTable;
        }


        public DataTable GetTenantData(string searchTerm = null)
        {
            DataTable TenantTable = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM tenant";

                    // Add a WHERE clause if a search term is provided
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE full_name LIKE @searchTerm OR government_id LIKE @searchTerm OR email LIKE @searchTerm OR mobile LIKE @searchTerm";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(TenantTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching tenant data: " + ex.Message);
            }

            return TenantTable;
        }

        public bool UpdateTenant(int id, string newFullName, string newEmail, string newMobile)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                UPDATE tenant
                SET full_name = @full_name, email = @email, mobile = @mobile
                WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@full_name", newFullName);
                        cmd.Parameters.AddWithValue("@email", newEmail);
                        cmd.Parameters.AddWithValue("@mobile", newMobile);
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if the update was successful
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating tenant: " + ex.Message);
                return false;
            }
        }

        public bool DeleteTenant(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Step 1: Retrieve the id_copy_path for the tenant
                    string idCopyPath = null;
                    string selectQuery = "SELECT id_copy_path FROM tenant WHERE id = @id";

                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idCopyPath = reader["id_copy_path"]?.ToString();
                            }
                        }
                    }

                    // Step 2: Delete the tenant record
                    string deleteQuery = "DELETE FROM tenant WHERE id = @id";

                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Step 3: Delete the image file from the file system if it exists
                            if (!string.IsNullOrEmpty(idCopyPath) && File.Exists(idCopyPath))
                            {
                                try
                                {
                                    File.Delete(idCopyPath);
                                    Console.WriteLine($"Deleted file: {idCopyPath}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Error deleting file: " + ex.Message);
                                }
                            }

                            return true; // Return true if the delete was successful
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting tenant: " + ex.Message);
                return false;
            }

            return false;
        }

        public bool InsertTenant(string fullName, string governmentId, string idCopyPath, string email, string mobile)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                INSERT INTO tenant (full_name, government_id, id_copy_path, email, mobile)
                VALUES (@full_name, @government_id, @id_copy_path, @email, @mobile)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@full_name", fullName);
                        cmd.Parameters.AddWithValue("@government_id", governmentId);
                        cmd.Parameters.AddWithValue("@id_copy_path", idCopyPath);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@mobile", mobile);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if the insertion was successful
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting tenant: " + ex.Message);
                return false;
            }
        }

        public DataTable GetEmployeeData(string searchTerm = null)
        {
            DataTable employeeTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT 
                        id, 
                        full_name, 
                        role, 
                        email, 
                        emp_password,
                        mobile, 
                        business_id, 
                        CAST(status AS CHAR) AS status, -- Ensure status is treated as a string
                        created_at 
                    FROM employee
                    WHERE emp_status = '1'";

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += "AND (full_name LIKE @searchTerm OR email LIKE @searchTerm OR mobile LIKE @searchTerm OR role LIKE @searchTerm)";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(employeeTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching employee data: " + ex.Message);
            }
            return employeeTable;
        }


        public bool UpdateEmployee(int id, string newFullName, string newEmail, string newMobile, string newPassword, string newRole)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    // Convert the password to a bcrypt hash
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

                    conn.Open();
                    string query = @"
                        UPDATE employee
                        SET full_name = @full_name, email = @email, mobile = @mobile, emp_password = @password, role = @role
                        WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@full_name", newFullName);
                        cmd.Parameters.AddWithValue("@email", newEmail);
                        cmd.Parameters.AddWithValue("@mobile", newMobile);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@role", newRole);
                        cmd.Parameters.AddWithValue("@id", id);
                        

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if the update was successful
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating tenant: " + ex.Message);
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Step 1: Delete the employee record
                    string deleteQuery = "UPDATE employee SET emp_status = '0' WHERE id = @id";

                    using (MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return true; // Return true if the delete was successful
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting Employee: " + ex.Message);
                return false;
            }

            return false;
        }

        public bool InsertEmployee(string fullName, string email, string mobile, string password, string role)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    // Convert the password to a bcrypt hash
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                    int business_id = 1;
                    conn.Open();
                    string query = @"
                        INSERT INTO employee (full_name, role, email, emp_password, mobile, business_id)
                        VALUES (@full_name, @role, @email, @password, @mobile, @business_id)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@full_name", fullName);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@business_id", business_id);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@mobile", mobile);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if the insertion was successful
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting employee: " + ex.Message);
                return false;
            }
        }

        public DataTable GetRentalAgreement_withname(string searchTerm = null)
        {
            DataTable rentalAgreementTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Query to fetch data from the rental_agreement_withname view
                    string query = @"
                        SELECT 
                            id, 
                            status, 
                            agreed_price, 
                            tenant_full_name, 
                            handled_by_employee_full_name
                        FROM 
                            rental_agreement_withname";

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE id LIKE @searchTerm OR status LIKE @searchTerm OR agreed_price LIKE @searchTerm OR tenant_full_name LIKE @searchTerm OR handled_by_employee_full_name LIKE @searchTerm";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(searchTerm))
                        {
                            cmd.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(rentalAgreementTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching rental agreement data: " + ex.Message);
            }
            return rentalAgreementTable;
        }

        public DataTable GetPayment_withname(string rentalAgreementId = null)
        {
            DataTable rentalPaymentTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Query to fetch data from the payment table with employee full name
                    string query = @"
                    SELECT 
                        p.*,
                        e.full_name AS received_by_employee_name
                    FROM 
                        payment p
                    LEFT JOIN 
                        employee e ON p.received_by_employee_id = e.id";

                    // Add a WHERE clause if a rentalAgreementId is provided
                    if (!string.IsNullOrEmpty(rentalAgreementId))
                    {
                        query += " WHERE p.id = @rentalAgreementId";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(rentalAgreementId))
                        {
                            cmd.Parameters.AddWithValue("@rentalAgreementId", rentalAgreementId);
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(rentalPaymentTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching payment data: " + ex.Message);
            }
            return rentalPaymentTable;
        }

        public DataTable GetRental_Fee(string rentalAgreementId = null)
        {
            DataTable rentalFeeTable = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Query to fetch data from the payment table with employee full name
                    string query = @"SELECT * FROM fee";

                    // Add a WHERE clause if a rentalAgreementId is provided
                    if (!string.IsNullOrEmpty(rentalAgreementId))
                    {
                        query += " WHERE rental_agreement_id = @rentalAgreementId";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrEmpty(rentalAgreementId))
                        {
                            cmd.Parameters.AddWithValue("@rentalAgreementId", rentalAgreementId);
                        }

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(rentalFeeTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching fee data: " + ex.Message);
            }
            return rentalFeeTable;
        }


        public bool IsUsernameInOwnerTable(string username)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM owner WHERE username = @username";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking owner table: " + ex.Message);
                return false;
            }
        }

        public bool IsUsernameInEmployeeTable(string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM employee WHERE email = @email";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        long count = (long)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error checking employee table: " + ex.Message);
                return false;
            }
        }

        public int GetSecurityQuestionCount(string username)
        {
            try
            {
                int ownerId = GetOwnerId(username);
                if (ownerId == -1) return 0;

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM owner_security_questions WHERE owner_id = @ownerId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ownerId", ownerId);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting security question count: " + ex.Message);
                return 0;
            }
        }

        public bool VerifySecurityAnswers(int ownerId, string answer1, string answer2, string answer3)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Get all answers for this owner
                    string query = "SELECT question_id, answer_hash FROM owner_security_questions WHERE owner_id = @ownerId";
                    Dictionary<int, string> correctAnswers = new Dictionary<int, string>();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ownerId", ownerId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                correctAnswers.Add(
                                    reader.GetInt32("question_id"),
                                    reader.GetString("answer_hash")
                                );
                            }
                        }
                    }

                    // Verify each answer
                    bool answer1Correct = BCrypt.Net.BCrypt.Verify(answer1, correctAnswers[1]);
                    bool answer2Correct = BCrypt.Net.BCrypt.Verify(answer2, correctAnswers[2]);
                    bool answer3Correct = BCrypt.Net.BCrypt.Verify(answer3, correctAnswers[3]);

                    return answer1Correct && answer2Correct && answer3Correct;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error verifying security answers: " + ex.Message);
                return false;
            }
        }

        public bool UpdateOwnerPassword(string username, string newPasswordHash)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE owner SET password_hash = @passwordHash WHERE username = @username";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@passwordHash", newPasswordHash);
                        cmd.Parameters.AddWithValue("@username", username);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating password: " + ex.Message);
                return false;
            }
        }

        public bool SetEmployeeOffline(string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE employee SET status = 'offline' WHERE email = @email";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting employee offline: " + ex.Message);
                return false;
            }
        }

        public DataRow GetInventoryDetails(string inventoryId)
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"SELECT i.*, p.name as product_name, pt.type_name as product_type, p.description, p.base_price, p.price_unit
                            FROM inventory i
                            JOIN product p ON i.product_id = p.id
                            JOIN product_type pt ON p.product_type_id = pt.id
                            WHERE i.id = @inventoryId";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@inventoryId", inventoryId);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching inventory details: " + ex.Message);
                return null;
            }
        }

        public bool RentProduct(string inventoryId, string tenantId, string employeeEmail, string price, string duration, string serialNum, string condition)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    int inventory = Convert.ToInt32(inventoryId);
                    int tenant = Convert.ToInt32(tenantId);

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Get employee id
                            string getEmployeeQuery = @"SELECT id FROM employee WHERE email = @employeeEmail";
                            int employeeId = 0;

                            using (MySqlCommand cmd = new MySqlCommand(getEmployeeQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@employeeEmail", employeeEmail);
                                object result = cmd.ExecuteScalar();
                                if (result == null)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                                employeeId = Convert.ToInt32(result);
                            }

                            // 2. Insert into rental_agreement
                            string insertAgreementQuery = @"INSERT INTO rental_agreement 
                                        (tenant_id, status, agreed_price, duration, handled_by_employee_id)
                                        VALUES (@tenantId, 'active', @price, @duration, @employeeId);
                                        SELECT LAST_INSERT_ID();";

                            int rentalAgreementId = 0;
                            using (MySqlCommand cmd = new MySqlCommand(insertAgreementQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@tenantId", tenant);
                                cmd.Parameters.AddWithValue("@price", price);
                                cmd.Parameters.AddWithValue("@duration", duration);
                                cmd.Parameters.AddWithValue("@employeeId", employeeId);

                                rentalAgreementId = Convert.ToInt32(cmd.ExecuteScalar());
                                if (rentalAgreementId <= 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }

                            // 3. Insert into rental_agreement_details
                            string insertDetailsQuery = @"INSERT INTO rental_agreement_details
                                        (rental_agreement_id, serial_number_id, check_out_date, condition_out)
                                        VALUES (@rentalAgreementId, @serialNum, CURDATE(), @condition)";

                            using (MySqlCommand cmd = new MySqlCommand(insertDetailsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@rentalAgreementId", rentalAgreementId);
                                cmd.Parameters.AddWithValue("@serialNum", serialNum);
                                cmd.Parameters.AddWithValue("@condition", condition);

                                int detailsRows = cmd.ExecuteNonQuery();
                                if (detailsRows <= 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine("Error in transaction: " + ex.Message);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error renting product: " + ex.Message);
                return false;
            }
        }

        public bool InsertFee(int rentalAgreementId, string feeType, decimal amount, string description)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction()) // Add transaction
                    {
                        try
                        {
                            // Verify rental agreement exists first
                            string checkQuery = "SELECT COUNT(*) FROM rental_agreement WHERE id = @rentalAgreementId";
                            using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@rentalAgreementId", rentalAgreementId);
                                int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (exists == 0)
                                {
                                    MessageBox.Show($"Rental agreement {rentalAgreementId} doesn't exist!");
                                    return false;
                                }
                            }

                            string query = @"INSERT INTO fee 
                            (rental_agreement_id, fee_type, amount, description) 
                            VALUES 
                            (@rentalAgreementId, @feeType, @amount, @description)";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@rentalAgreementId", rentalAgreementId);
                                cmd.Parameters.AddWithValue("@feeType", feeType);
                                cmd.Parameters.AddWithValue("@amount", amount);
                                cmd.Parameters.AddWithValue("@description", description);

                                int rowsAffected = cmd.ExecuteNonQuery();
                                transaction.Commit(); // Explicit commit
                                return rowsAffected > 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Failed to insert fee: {ex.Message}", "Error");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed: {ex.Message}", "Error");
                return false;
            }
        }




    }
}