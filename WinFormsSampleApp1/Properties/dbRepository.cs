using System;
using System.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using WinFormsSampleApp1.Properties.Models;

namespace WinFormsSampleApp1.Properties
{
    public class dbRepository
    {
        // Define the connection string
        private string ConnectionString = "Server=127.0.0.1;Port=3306;Database=RentaHALL2;Uid=root;Pwd=Eric@tripulca.com;";

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
        public (string PasswordHash, string Role) GetEmployeeCredentials(string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT emp_password, role FROM employee WHERE email = @email";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string passwordHash = reader.GetString("emp_password");
                                string role = reader.GetString("role");
                                return (passwordHash, role); // Return the hashed password and role
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving employee credentials: " + ex.Message);
            }
            return (null, null); // Return null if no match is found
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
                    string query = "SELECT SUM(total_amount) AS TotalRevenue FROM payment";
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
        public int GetEmpNo()
        {
            int empCount = 0;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) AS EmpCount FROM employee";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                        if (result != null && result != DBNull.Value)
                        {
                            empCount = Convert.ToInt32(result); // Convert the result to an integer
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching employee count: " + ex.Message);
            }

            return empCount;
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
        public void InsertProduct(int productTypeId, string productName, string description, decimal basePrice, string priceUnit)
        {
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
                        0, -- maintenance_quantity starts at 0
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting product: " + ex.Message);
            }
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
        public void InsertInventoryItem(int productId, string serialNumber, string size)
        {
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
            }
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
                        FROM product p
                        JOIN product_type pt ON p.product_type_id = pt.id
                        WHERE pt.prd_code = @prdCode";

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




    }
}