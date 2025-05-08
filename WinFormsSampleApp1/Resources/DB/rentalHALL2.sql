-- Complete Rental Management System Schema
DROP DATABASE IF EXISTS `RentaHALL2`;
CREATE DATABASE `RentaHALL2`;
USE `RentaHALL2`;

-- Admin
CREATE TABLE admin (
    id INT NOT NULL AUTO_INCREMENT,
    username VARCHAR(100) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    UNIQUE (username)
);



-- Owner
CREATE TABLE owner (
    id INT NOT NULL AUTO_INCREMENT,
    username VARCHAR(100) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    UNIQUE (username)
);




-- Business Information
CREATE TABLE business (
    id INT NOT NULL AUTO_INCREMENT,
    owner_id INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    FOREIGN KEY (owner_id) REFERENCES owner(id),
    UNIQUE (name, owner_id)
);



-- Employee Table
CREATE TABLE employee (
    id INT NOT NULL AUTO_INCREMENT,
    full_name VARCHAR(255) NOT NULL,
    role ENUM('manager', 'staff') NOT NULL,  -- Can be 'manager' or 'staff'
    email VARCHAR(255) NOT NULL UNIQUE,
    emp_password VARCHAR(255) NOT NULL,
    mobile VARCHAR(20),
    business_id INT NOT NULL,  -- Reference to business to know which business they belong to
    status ENUM('active','offline') DEFAULT 'offline', -- Reference to activity log of employees
    emp_status ENUM('1','0') DEFAULT '1',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    
    PRIMARY KEY (id),
    FOREIGN KEY (business_id) REFERENCES business(id)
);




CREATE TABLE employee_log (
    id INT NOT NULL AUTO_INCREMENT,
    employee_id INT NOT NULL,
    login_time DATETIME DEFAULT NULL,
    logout_time DATETIME DEFAULT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    FOREIGN KEY (employee_id) REFERENCES employee(id)
);

-- Product Category Table
CREATE TABLE product_type (
    id INT NOT NULL AUTO_INCREMENT,
    type_name VARCHAR(100) NOT NULL UNIQUE,
    prd_code VARCHAR(100) NOT NULL UNIQUE,
    PRIMARY KEY (id)
);





-- Main Product Table
CREATE TABLE product (
    id INT NOT NULL AUTO_INCREMENT,
    business_id INT NOT NULL,
    product_type_id INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    base_price DECIMAL(10, 2) NOT NULL,
    price_unit ENUM('hour', 'day', 'week', 'month', 'year') NOT NULL,
    total_quantity INT NOT NULL DEFAULT 0,
    available_quantity INT NOT NULL DEFAULT 0,
    rented_quantity INT NOT NULL DEFAULT 0,
    maintenance_quantity INT NOT NULL DEFAULT 0,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    FOREIGN KEY (business_id) REFERENCES business(id),
    FOREIGN KEY (product_type_id) REFERENCES product_type(id)
);



-- Individual Inventory Items Table
CREATE TABLE inventory (
    id INT NOT NULL AUTO_INCREMENT,
    product_id INT NOT NULL,
    serial_number VARCHAR(255) COMMENT 'Unique identifier for physical items',
    size VARCHAR(4) NOT NULL,
    status ENUM('available', 'rented', 'maintenance') DEFAULT 'available',
    current_condition VARCHAR(255),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    FOREIGN KEY (product_id) REFERENCES product(id) ON DELETE CASCADE,
    UNIQUE (serial_number)
);




-- Tenant/Renter Information
CREATE TABLE tenant (
    id INT NOT NULL AUTO_INCREMENT,
    full_name VARCHAR(255) NOT NULL,
    government_id VARCHAR(100) NOT NULL,
    id_copy_path VARCHAR(255),
    email VARCHAR(255) NOT NULL,
    mobile VARCHAR(20) NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    UNIQUE (government_id),
    UNIQUE (email)
);




-- Rental Agreements Table
CREATE TABLE rental_agreement (
    id INT NOT NULL AUTO_INCREMENT,
    tenant_id INT NOT NULL,
    status ENUM('active', 'completed', 'terminated','pending') DEFAULT 'active',
    agreed_price DECIMAL(10, 2) NOT NULL,
    duration ENUM('day', 'week', 'month', 'year') NOT NULL,
    handled_by_employee_id INT,  -- Employee who handled the rental
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    
    PRIMARY KEY (id),
    FOREIGN KEY (tenant_id) REFERENCES tenant(id),
    FOREIGN KEY (handled_by_employee_id) REFERENCES employee(id)
);





-- Rental Agreement Details (Individual Items)
CREATE TABLE rental_agreement_details (
    id INT NOT NULL AUTO_INCREMENT,
    rental_agreement_id INT NOT NULL,
    serial_number_id VARCHAR(255),
    check_out_date DATE,
    end_date DATE,
    returned_date DATETIME,
    condition_out VARCHAR(255),
    condition_in VARCHAR(255),
    
    PRIMARY KEY (id),
    FOREIGN KEY (rental_agreement_id) REFERENCES rental_agreement(id),
    FOREIGN KEY (serial_number_id) REFERENCES inventory(serial_number),
    UNIQUE (serial_number_id)
);





-- Additional Fees Table
CREATE TABLE fee (
    id INT NOT NULL AUTO_INCREMENT,
    rental_agreement_id INT NOT NULL,
    fee_type ENUM('rent', 'water', 'electric', 'internet', 'late', 'damage', 'other') NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    due_date DATE NOT NULL,
    description TEXT,
    paid BOOLEAN DEFAULT FALSE,
    PRIMARY KEY (id),
    FOREIGN KEY (rental_agreement_id) REFERENCES rental_agreement(id)
);




-- Payment Records
CREATE TABLE payment (
    id INT NOT NULL AUTO_INCREMENT,
    rental_agreement_id INT NOT NULL,
    total_amount DECIMAL(10, 2) DEFAULT 0,
    payment_date DATETIME DEFAULT NULL,
    payment_method ENUM('cash', 'credit_card', 'bank_transfer', 'check', 'other') DEFAULT NULL,
    payment_status ENUM('done', 'pending') NOT NULL,
    reference_number VARCHAR(50) DEFAULT NULL,
    received_by_employee_id INT DEFAULT NULL,  -- Employee who received the payment
    PRIMARY KEY (id),
    FOREIGN KEY (rental_agreement_id) REFERENCES rental_agreement(id),
    FOREIGN KEY (rental_agreement_id) REFERENCES fee(rental_agreement_id),
    FOREIGN KEY (received_by_employee_id) REFERENCES employee(id)
);


CREATE TABLE notification (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tenant_id INT NOT NULL,
    product_name VARCHAR(255),
    serial_number_id VARCHAR(255),
    end_date DATE NOT NULL,
    
    FOREIGN KEY (tenant_id) REFERENCES tenant(id),
    FOREIGN KEY (serial_number_id) REFERENCES inventory(serial_number)
);

CREATE TABLE  annual_revenue (
    id INT AUTO_INCREMENT PRIMARY KEY,
    year YEAR NOT NULL,
    total_revenue DECIMAL(10, 2) NOT NULL
);


-- Trigger for Login
DELIMITER $$
CREATE TRIGGER log_employee_login
AFTER UPDATE ON employee
FOR EACH ROW
BEGIN
    IF NEW.status = 'active' AND OLD.status != 'active' THEN
        INSERT INTO employee_log (employee_id, login_time)
        VALUES (NEW.id, NOW());
    END IF;
END$$
DELIMITER ;

-- Trigger for Logout
DELIMITER $$
CREATE TRIGGER log_employee_logout
AFTER UPDATE ON employee
FOR EACH ROW
BEGIN
    IF NEW.status = 'offline' AND OLD.status != 'offline' THEN
        UPDATE employee_log
        SET logout_time = NOW()
        WHERE employee_id = NEW.id
          AND logout_time IS NULL
        ORDER BY id DESC
        LIMIT 1;
    END IF;
END$$
DELIMITER ;


-- Trigger: Ensure Product Availability Before Inserting into rental_agreement
DELIMITER $$

CREATE TRIGGER check_product_availability
BEFORE INSERT ON rental_agreement_details
FOR EACH ROW
BEGIN
    DECLARE item_status VARCHAR(20);
    DECLARE rental_duration ENUM('day', 'week', 'month', 'year');
    DECLARE calculated_end_date DATE; -- Change to DATE type

    -- Check the status of the inventory item being rented
    SELECT status INTO item_status
    FROM inventory
    WHERE serial_number = NEW.serial_number_id;

    -- If the item is not available, raise an error
    IF item_status != 'available' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Item is not available for rental';
    END IF;

    -- Get the rental duration from the associated rental agreement
    SELECT duration INTO rental_duration
    FROM rental_agreement
    WHERE id = NEW.rental_agreement_id;

    -- Calculate the end_date based on the rental duration
    CASE rental_duration
        WHEN 'day' THEN
            SET calculated_end_date = DATE(DATE_ADD(CURDATE(), INTERVAL 1 DAY)); -- Use CURDATE() and DATE()
        WHEN 'week' THEN
            SET calculated_end_date = DATE(DATE_ADD(CURDATE(), INTERVAL 1 WEEK));
        WHEN 'month' THEN
            SET calculated_end_date = DATE(DATE_ADD(CURDATE(), INTERVAL 1 MONTH));
        WHEN 'year' THEN
            SET calculated_end_date = DATE(DATE_ADD(CURDATE(), INTERVAL 1 YEAR));
        ELSE
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Invalid rental duration';
    END CASE;

    -- Set the end_date (no time component)
    SET NEW.end_date = calculated_end_date;
END$$

DELIMITER ;


-- Trigger: Update Inventory Status to "Rented" After Confirming Rental

DELIMITER $$

CREATE TRIGGER update_inventory_to_rented
AFTER INSERT ON rental_agreement_details
FOR EACH ROW
BEGIN
    DECLARE item_product_id INT;

    -- Update the inventory status to 'rented'
    UPDATE inventory
    SET status = 'rented'
    WHERE serial_number = NEW.serial_number_id;

    -- Retrieve the product_id for the inventory item
    SELECT product_id INTO item_product_id
    FROM inventory
    WHERE serial_number = NEW.serial_number_id;

    -- Decrement the total_quantity and increment the rented_quantity in the product table
    UPDATE product
    SET available_quantity = available_quantity - 1,
        rented_quantity = rented_quantity + 1
    WHERE id = item_product_id;
END$$

DELIMITER ;














	

DELIMITER $$

CREATE TRIGGER before_inventory_delete
BEFORE DELETE ON inventory
FOR EACH ROW
BEGIN
    -- Prevent deletion if the item is currently rented or under maintenance
    IF OLD.status = 'rented' OR OLD.status = 'maintenance' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Cannot delete rented or maintenance inventory items';
    END IF;

    -- Decrement total_quantity in the product table
    UPDATE product
    SET total_quantity = total_quantity - 1,
		available_quantity = available_quantity - 1
    WHERE product_type_id = OLD.product_id;
END$$

DELIMITER ;

DELIMITER ;


  -- Trigger: reference_number for different payment_method
DELIMITER $$

CREATE TRIGGER before_payment_insert
BEFORE INSERT ON payment
FOR EACH ROW
BEGIN
    DECLARE next_id INT;

    -- Handle cash payments
    IF NEW.payment_method = 'cash' AND   NEW.payment_status = 'done' THEN
        -- Get the next available number for cash payments
        SELECT COALESCE(MAX(CAST(SUBSTRING(reference_number, 6) AS UNSIGNED)), 0) + 1
        INTO next_id
        FROM payment
        WHERE reference_number LIKE 'CASH-%';

        SET NEW.reference_number = CONCAT('CASH-', next_id);

    -- Handle bank transfer payments
    ELSEIF NEW.payment_method = 'bank_transfer' THEN
        -- Ensure the reference number starts with "BT-"
        SET NEW.reference_number = CONCAT('BT-', NEW.reference_number);

    -- Handle credit card payments
    ELSEIF NEW.payment_method = 'credit_card' THEN
        -- Ensure the reference number starts with "CC-"
        SET NEW.reference_number = CONCAT('CC-', NEW.reference_number);

    -- Handle check payments
    ELSEIF NEW.payment_method = 'check' THEN
        -- Ensure the reference number starts with "CHK-"
        SET NEW.reference_number = CONCAT('CHK-', NEW.reference_number);

    -- Handle other payments
    ELSEIF NEW.payment_method = 'other' THEN
        -- Ensure the reference number starts with "OTH-"
        SET NEW.reference_number = CONCAT('OTH-', NEW.reference_number);
    END IF;
END$$

DELIMITER ;

-- Trigger: Update Inventory Status When Terminating a Rental Agreement

DELIMITER $$

CREATE TRIGGER update_inventory_on_termination
AFTER UPDATE ON rental_agreement
FOR EACH ROW
BEGIN
    -- Check if the rental agreement status is terminated
    IF NEW.status = 'terminated' THEN
        -- Update the inventory status to 'available' or 'maintenance'
        UPDATE inventory
        SET status = CASE
            WHEN OLD.status = 'rented' THEN 'maintenance' -- Transition from rented to maintenance
            ELSE 'available' -- Default to available if not rented
        END
        WHERE serial_number IN (
            SELECT serial_number_id
            FROM rental_agreement_details
            WHERE rental_agreement_id = NEW.id
        );

    -- Check if the rental agreement status is active
    ELSEIF NEW.status = 'active' THEN
        -- Insert into the payment table
        INSERT INTO payment (rental_agreement_id, payment_status)
        VALUES (NEW.id, 'pending');

        -- Insert a new row into the fee table
        INSERT INTO fee (rental_agreement_id, fee_type, amount, due_date, description)
        SELECT 
            NEW.id AS rental_agreement_id,
            'rent' AS fee_type,
            agreed_price AS amount,
            CASE NEW.duration
                WHEN 'day' THEN DATE_ADD(CURDATE(), INTERVAL 1 DAY)
                WHEN 'week' THEN DATE_ADD(CURDATE(), INTERVAL 1 WEEK)
                WHEN 'month' THEN DATE_ADD(CURDATE(), INTERVAL 1 MONTH)
                WHEN 'year' THEN DATE_ADD(CURDATE(), INTERVAL 1 YEAR)
            END AS due_date,
            'Rental Fee' AS description
        FROM rental_agreement
        WHERE id = NEW.id;
    END IF;
END$$

DELIMITER ;
	-- Trigger: Update conditon on return in rental aggreement detail

DELIMITER $$

CREATE TRIGGER update_current_condition_on_return
AFTER UPDATE ON rental_agreement_details
FOR EACH ROW
BEGIN
    -- Check if the product has been returned (returned_date is set)
    IF NEW.returned_date IS NOT NULL THEN
        -- Update the current_condition in the inventory table to 'used'
        UPDATE inventory
        SET current_condition = 'used'
        WHERE serial_number = NEW.serial_number_id;
    END IF;
END$$

DELIMITER ;

  -- Trigger: Update Product Quantity in Inventory
DELIMITER $$

CREATE TRIGGER sync_quantity_on_inventory_update
AFTER UPDATE ON inventory
FOR EACH ROW
BEGIN
    -- If the status changes TO 'available'
    IF NEW.status = 'available' AND OLD.status = 'rented' THEN
        UPDATE product
        SET available_quantity = available_quantity + 1,
			rented_quantity = rented_quantity + 1
        WHERE id = NEW.product_id;

    -- If the status changes FROM 'available' TO 'rented'
    ELSEIF NEW.status = 'maintenance' AND OLD.status = 'available' THEN
        UPDATE product
        SET available_quantity = available_quantity - 1,
			maintenance_quantity = maintenance_quantity + 1
        WHERE id = NEW.product_id;
	
    -- If the status changes FROM 'available' TO 'maintenance' or 'rented'
    ELSEIF NEW.status = 'available' AND OLD.status = 'maintenance' THEN
        UPDATE product
        SET available_quantity = available_quantity + 1,
			maintenance_quantity = maintenance_quantity - 1
        WHERE id = NEW.product_id;
    END IF;
END$$

DELIMITER ;

DELIMITER $$

CREATE TRIGGER sync_quantity_on_inventory_insert
AFTER INSERT ON inventory
FOR EACH ROW
BEGIN
    -- Increment total_quantity in the product table
    UPDATE product
    SET total_quantity = total_quantity + 1
		
    WHERE id = NEW.product_id;

    -- If the new inventory item's status is 'available', increment available_quantity
    IF NEW.status = 'available' THEN
        UPDATE product
        SET available_quantity = available_quantity + 1
        WHERE id = NEW.product_id;
    END IF;
END$$

DELIMITER ;


 -- Trigger: Update due_date for fee 
DELIMITER $$

CREATE TRIGGER set_fee_due_date_from_rental_details
BEFORE INSERT ON fee
FOR EACH ROW
BEGIN
    DECLARE rental_duration ENUM('day', 'week', 'month', 'year');
    DECLARE calculated_due_date DATETIME;
    
    

    -- Retrieve the end_date from the rental_agreement_details table
    SELECT duration INTO rental_duration
    FROM rental_agreement
    WHERE id = NEW.rental_agreement_id;

    -- Calculate the end_date based on the rental duration
    CASE rental_duration
        WHEN 'day' THEN
            SET calculated_due_date = DATE_ADD(NOW(), INTERVAL 1 DAY);
        WHEN 'week' THEN
            SET calculated_due_date = DATE_ADD(NOW(), INTERVAL 1 WEEK);
        WHEN 'month' THEN
            SET calculated_due_date = DATE_ADD(NOW(), INTERVAL 1 MONTH);
        WHEN 'year' THEN
            SET calculated_due_date = DATE_ADD(NOW(), INTERVAL 1 YEAR);
        ELSE
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Invalid rental duration';
    END CASE;

    -- Set the end_date
    SET NEW.due_date = calculated_due_date;
END$$

DELIMITER ;

DELIMITER $$

CREATE PROCEDURE update_payment_and_related_tables(
    IN p_rental_agreement_id INT,
    IN p_payment_method VARCHAR(50),
    IN p_payment_status ENUM('done', 'pending'),
    IN p_reference_number VARCHAR(50),
    IN p_received_by_employee_id INT
)
BEGIN
    -- Update the payment table
    UPDATE payment
    SET payment_method = p_payment_method,
        payment_status = p_payment_status,
        reference_number = p_reference_number,
        received_by_employee_id = p_received_by_employee_id,
        payment_date = NOW()
    WHERE rental_agreement_id = p_rental_agreement_id AND payment_status = 'pending';

    -- Update the rental_agreement status to 'completed'
    UPDATE rental_agreement
    SET status = 'completed'
    WHERE id = p_rental_agreement_id;
    
    -- Update the all connected fee status t0 1 as done
    UPDATE fee
    SET paid = 1
    WHERE rental_agreement_id = p_rental_agreement_id AND paid = 0;
    
END$$

DELIMITER ;



DELIMITER $$

CREATE TRIGGER after_fee_insert
AFTER INSERT ON fee
FOR EACH ROW
BEGIN
    DECLARE total_amount DOUBLE;

    -- Step 1: Calculate the total fees for the rental agreement
    SELECT SUM(amount) INTO total_amount
    FROM fee
    WHERE rental_agreement_id = NEW.rental_agreement_id;

    -- Step 2: Check if a payment record exists for the rental agreement
    IF NOT EXISTS (
        SELECT 1
        FROM payment
        WHERE rental_agreement_id = NEW.rental_agreement_id AND payment_status = 'pending'
    ) THEN
        -- Insert a new payment record if none exists
        INSERT INTO payment (rental_agreement_id, payment_status, total_amount)
        VALUES (NEW.rental_agreement_id, 'pending', total_amount);
    ELSE
        -- Update the existing payment record
        UPDATE payment
        SET total_amount = total_amount
        WHERE rental_agreement_id = NEW.rental_agreement_id AND payment_status = 'pending';
    END IF;
END$$

DELIMITER ;

DELIMITER $$

CREATE TRIGGER after_rental_agreement_insert
AFTER INSERT ON rental_agreement
FOR EACH ROW
BEGIN
    DECLARE v_due_date DATE;
    
    -- Calculate the due_date based on the duration
    CASE NEW.duration
        WHEN 'day' THEN SET v_due_date = DATE_ADD(CURDATE(), INTERVAL 1 DAY);
        WHEN 'week' THEN SET v_due_date = DATE_ADD(CURDATE(), INTERVAL 1 WEEK);
        WHEN 'month' THEN SET v_due_date = DATE_ADD(CURDATE(), INTERVAL 1 MONTH);
        WHEN 'year' THEN SET v_due_date = DATE_ADD(CURDATE(), INTERVAL 1 YEAR);
        ELSE
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Invalid rental duration';
    END CASE;
    
    -- Insert into the fee table
    INSERT INTO fee (rental_agreement_id, fee_type, amount, due_date, description)
    VALUES (NEW.id, 'rent', NEW.agreed_price, v_due_date, 'Rental fee');
    
END$$

DELIMITER ;





	-- Stored Procedures Without Cursor to Marks all inventory items for a specific product as "maintenance"
DELIMITER $$

CREATE PROCEDURE mark_inventory_as_maintenance(IN product_id_param INT)
BEGIN
    UPDATE inventory
    SET status = 'maintenance'
    WHERE id = product_id_param;
END$$

DELIMITER ;

-- Stored Procedures Without Cursor to update total_amount in payment table
-- DELIMITER $$

-- CREATE PROCEDURE calculate_total_fees(IN agreement_id INT, OUT total DECIMAL(10, 2))
-- BEGIN
--     -- Calculate the total fees for the given rental agreement
--     SELECT SUM(amount) INTO total
--     FROM fee
--     WHERE rental_agreement_id = agreement_id;
--     
--     -- Update the total_amount column in the payment table
--     UPDATE payment
--     SET total_amount = total
--     WHERE rental_agreement_id = agreement_id;
-- END$$

-- DELIMITER ;

-- Stored Procedures With Cursor to update employee status to offline who have been active for too long
DELIMITER $$

CREATE PROCEDURE update_employee_status_and_count()
BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE emp_id INT;
    DECLARE emp_status VARCHAR(50);
    DECLARE total_active INT DEFAULT 0;
    DECLARE total_offline INT DEFAULT 0;

    -- Declare a cursor to fetch all employees
    DECLARE cur CURSOR FOR 
        SELECT id, status 
        FROM employee;

    -- Handler to set the 'done' flag when no more rows are found
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

    OPEN cur;

    read_loop: LOOP
        FETCH cur INTO emp_id, emp_status;
        IF done THEN
            LEAVE read_loop;
        END IF;

        -- Check the status of the employee
        IF emp_status = 'active' THEN
            -- Increment the active count
            SET total_active = total_active + 1;
        ELSEIF emp_status = 'offline' THEN
            -- Increment the offline count
            SET total_offline = total_offline + 1;
        END IF;
    END LOOP;

    CLOSE cur;

    -- Output the total counts
    SELECT CONCAT('Total Active Employees: ', total_active) AS active_count,
           CONCAT('Total Offline Employees: ', total_offline) AS offline_count;
END$$

DELIMITER ;

-- Stored Procedures With Cursor to Provides a detailed report of all rental agreements for a specific tenant.
DELIMITER $$

CREATE PROCEDURE generate_rental_report(IN tenant_id_param INT)
BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE agreement_id INT;
    DECLARE tenant_name VARCHAR(255);
    
    -- Declare a cursor to fetch rental agreements for the specific tenant
    DECLARE cur CURSOR FOR 
        SELECT ra.id, t.full_name 
        FROM rental_agreement ra
        JOIN tenant t ON ra.tenant_id = t.id
        WHERE ra.tenant_id = tenant_id_param;
    
    -- Handler to set the 'done' flag when no more rows are found
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

    -- Create a temporary table to store the results
    CREATE TEMPORARY TABLE IF NOT EXISTS temp_rental_report (
        report_line VARCHAR(255)
    );

    -- Open the cursor
    OPEN cur;

    -- Loop through the cursor
    read_loop: LOOP
        FETCH cur INTO agreement_id, tenant_name;
        IF done THEN
            LEAVE read_loop;
        END IF;

        -- Insert each rental agreement into the temporary table
        INSERT INTO temp_rental_report (report_line)
        VALUES (CONCAT('Tenant: ', tenant_name, ', Agreement ID: ', agreement_id));
    END LOOP;

    -- Close the cursor
    CLOSE cur;

    -- Return the results from the temporary table
    SELECT report_line AS rental_report FROM temp_rental_report;

    -- Drop the temporary table
    DROP TEMPORARY TABLE IF EXISTS temp_rental_report;
END$$

DELIMITER ;


--  View: Track Rental History (Non-Updatable)

CREATE OR REPLACE VIEW rental_history AS
SELECT 
    t.full_name AS tenant_name,
    ra.status AS rental_status,
    ra.id AS rental_agreement_id,
	ra.duration AS rental_duration,
    rad.check_out_date,
    rad.end_date AS must_end_by,
    rad.returned_date,
    pmt.total_amount, -- Include total_amount from payment
    pmt.reference_number, -- Include reference_number from payment
    e1.full_name AS renting_employee,
    e2.full_name AS payment_received_by
FROM 
    rental_agreement ra
JOIN 
    tenant t ON ra.tenant_id = t.id
LEFT JOIN 
    rental_agreement_details rad ON ra.id = rad.rental_agreement_id
LEFT JOIN 
    payment pmt ON ra.id = pmt.rental_agreement_id -- Join payment using rental_agreement_id
LEFT JOIN 
    employee e1 ON ra.handled_by_employee_id = e1.id
LEFT JOIN 
    employee e2 ON pmt.received_by_employee_id = e2.id
WHERE 
    ra.status = 'completed';



-- View to store business and assigned employees (Non-Updatable)
CREATE OR REPLACE VIEW business_with_employees AS
SELECT 
    b.id AS business_id,
    b.name AS business_name,
    e.id AS employee_id,
    e.full_name AS employee_name,
    e.role AS employee_role,
    e.email AS employee_email,
    e.mobile AS employee_mobile
FROM 
    business b
LEFT JOIN 
    employee e
ON 
    b.id = e.business_id;

--  View: Employee log history (Non-Updatable)
CREATE VIEW employee_activity_log AS
SELECT 
    e.id AS employee_id,
    e.full_name AS employee_name,
    e.role AS employee_role,
    l.login_time,
    l.logout_time
FROM 
    employee e
LEFT JOIN 
    employee_log l
ON 
    e.id = l.employee_id
ORDER BY 
    l.login_time DESC;
    
CREATE OR REPLACE VIEW rental_agreement_withname AS
SELECT 
    ra.id,
    ra.status,
    ra.agreed_price,
    t.full_name AS tenant_full_name,
    e.full_name AS handled_by_employee_full_name,
    ra.created_at
FROM 
    rental_agreement ra
JOIN 
    tenant t ON ra.tenant_id = t.id
JOIN 
    employee e ON ra.handled_by_employee_id = e.id;    

--  View: Available  item in Inventory  (Updatable)
CREATE OR REPLACE VIEW available_inventory AS
SELECT id, product_id, serial_number, size, status, current_condition
FROM inventory
WHERE status = 'available';

--  View: Product Rental Summary
CREATE OR REPLACE VIEW product_rental_summary AS
SELECT 
    p.id AS product_id,
    p.name AS product_name,
    COUNT(rad.serial_number_id) AS total_rentals
FROM product p
LEFT JOIN inventory i ON p.id = i.product_id
LEFT JOIN rental_agreement_details rad ON i.serial_number = rad.serial_number_id
GROUP BY p.id, p.name;





-- Activity 4: Stored Functions
-- 1 stored function with int/double as return type
-- 1 stored function with char as return type
-- 1 stored function used in View
-- 2 stored functions used in the Stored procedure


DELIMITER $$
 -- Stored Function with INT/DOUBLE as Return Type
 
CREATE FUNCTION calculate_tenant_revenue(tenant_id_param INT) 
RETURNS DOUBLE
DETERMINISTIC
BEGIN
    DECLARE total_revenue DOUBLE;

    SELECT SUM(agreed_price) INTO total_revenue
    FROM rental_agreement
    WHERE tenant_id = tenant_id_param AND status = 'completed';

    RETURN IFNULL(total_revenue, 0);
END$$

DELIMITER ;

DELIMITER $$
 -- Stored Function with CHAR as Return Type
 
CREATE FUNCTION get_inventory_status(serial_number_param VARCHAR(255)) 
RETURNS CHAR(20)
DETERMINISTIC
BEGIN
    DECLARE item_status CHAR(20);

    SELECT status INTO item_status
    FROM inventory
    WHERE serial_number = serial_number_param;

    RETURN IFNULL(item_status, 'Unknown');
END$$

DELIMITER ;


DELIMITER $$
 -- Stored Function Used in a View: Product Rental Activity
CREATE FUNCTION count_active_rentals_for_product(product_id_param INT) 
RETURNS INT
DETERMINISTIC
BEGIN
    DECLARE active_count INT;

    SELECT COUNT(*) INTO active_count
    FROM rental_agreement_details rad
    JOIN inventory i ON rad.serial_number_id = i.serial_number
    JOIN rental_agreement ra ON rad.rental_agreement_id = ra.id
    WHERE i.product_id = product_id_param AND ra.status = 'active';

    RETURN IFNULL(active_count, 0);
END$$

DELIMITER ;

--  View: Product Rental Activity
CREATE OR REPLACE VIEW product_rental_activity AS
SELECT 
    p.id AS product_id,
    p.name AS product_name,
    count_active_rentals_for_product(p.id) AS active_rentals_count
FROM 
    product p;
    

 -- Two Stored Functions Used in a Stored Procedure
DELIMITER $$

 -- Stored Function 1: Calculate Total Fees for a Rental Agreement
 
DELIMITER $$

CREATE FUNCTION calculate_total_fees_for_agreement(agreement_id_param INT) 
RETURNS DOUBLE
DETERMINISTIC
BEGIN
    DECLARE total_fees DOUBLE;

    -- Calculate the sum of all fees for the given rental agreement
    SELECT SUM(amount) INTO total_fees
    FROM fee
    WHERE rental_agreement_id = agreement_id_param AND paid = 0;

    -- Return 0 if no fees exist for the rental agreement
    RETURN IFNULL(total_fees, 0);
END$$

DELIMITER ;

DELIMITER $$
 -- Stored Function 2: Get the Name of the Tenant for a Rental Agreement
 
CREATE FUNCTION get_tenant_name_for_agreement(agreement_id_param INT) 
RETURNS VARCHAR(255)
DETERMINISTIC
BEGIN
    DECLARE tenant_name VARCHAR(255);

    SELECT t.full_name INTO tenant_name
    FROM rental_agreement ra
    JOIN tenant t ON ra.tenant_id = t.id
    WHERE ra.id = agreement_id_param;

    RETURN IFNULL(tenant_name, 'Unknown');
END$$

DELIMITER ;


 -- Stored Procedure Using Both Functions
-- DELIMITER $$

-- CREATE PROCEDURE generate_rental_agreement_report(IN agreement_id_param INT)
-- BEGIN
--     DECLARE tenant_name VARCHAR(255);
--     DECLARE total_fees DOUBLE;

--     -- Use the stored functions
--     SET tenant_name = get_tenant_name_for_agreement(agreement_id_param);
--     SET total_fees = calculate_total_fees_for_agreement(agreement_id_param);

--     -- Display the report
--     SELECT 
--         CONCAT('Tenant: ', tenant_name) AS tenant_info,
--         CONCAT('Total Fees: ', total_fees) AS total_fees_info;
-- END$$

-- DELIMITER ;

--  View: Active rentals  (Updatable)
CREATE OR REPLACE VIEW active_rentals AS
SELECT 
    ra.id AS rental_agreement_id,
    t.full_name AS tenant_full_name,
    t.email AS tenant_email,
    t.mobile AS tenant_mobile,
    rad.serial_number_id,
    rad.end_date,
    ra.duration,
    ra.status,
    calculate_total_fees_for_agreement(ra.id) AS total_amount_due,
    e.full_name AS employee_full_name
FROM 
    rental_agreement ra
JOIN 
    tenant t ON ra.tenant_id = t.id
LEFT JOIN 
    rental_agreement_details rad ON ra.id = rad.rental_agreement_id
LEFT JOIN 
    employee e ON ra.handled_by_employee_id = e.id
WHERE 
    ra.status = 'active'
    AND rad.returned_date IS NULL;


















 -- Stored Procedure: For identifying active rental in rental_agreement where end_date is exactly 1 day ahead of the current date
DELIMITER $$

CREATE PROCEDURE notify_rental_agreements_one_day_before()
BEGIN
    DECLARE done INT DEFAULT 0;
    DECLARE agreement_id INT;
    DECLARE tenant_id INT;
    DECLARE tenant_name VARCHAR(255);
    DECLARE product_name VARCHAR(255);
    DECLARE serial_number_id VARCHAR(255);
    DECLARE end_date DATE;

    -- Declare the cursor with the necessary joins
    DECLARE cur CURSOR FOR 
        SELECT ra.id, ra.tenant_id, p.name, rad.serial_number_id, rad.end_date
        FROM rental_agreement ra
        JOIN tenant t ON ra.tenant_id = t.id
        JOIN rental_agreement_details rad ON ra.id = rad.rental_agreement_id
        JOIN inventory i ON rad.serial_number_id = i.serial_number
        JOIN product p ON i.product_id = p.id
        WHERE ra.status = 'active' 
          AND rad.end_date = DATE_ADD(CURDATE(), INTERVAL 1 DAY);

    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

    OPEN cur;

    read_loop: LOOP
        FETCH cur INTO agreement_id, tenant_id, product_name, serial_number_id, end_date;
        IF done THEN
            LEAVE read_loop;
        END IF;

        -- Insert the reminder into the notification table
        INSERT INTO notification (tenant_id, product_name, serial_number_id, end_date)
        VALUES (tenant_id, product_name, serial_number_id, end_date);
    END LOOP;

    CLOSE cur;
END$$

DELIMITER ;


 -- Event: Daily Recurring Event at 8:00 AM and call the notify_pending_rental_agreements_one_day_before().
DELIMITER $$

CREATE EVENT daily_notify_rental_agreements
ON SCHEDULE EVERY 1 MINUTE
STARTS '2025-04-02 08:00:00' -- Starts at 8:00 AM
DO
BEGIN
    CALL notify_rental_agreements_one_day_before();
END$$

DELIMITER ;

 -- Event: Daily Recurring Event at 12:00 AM and deletes rows from the notification table.
DELIMITER $$

CREATE EVENT daily_clear_notifications
ON SCHEDULE EVERY 1 MINUTE
STARTS '2025-04-02 08:01:00' -- Starts at midnight 
DO
BEGIN
    -- Delete all rows from the notification table
    DELETE FROM notification;
END$$

DELIMITER ;


 -- Event: One-time Event at 12:00 AM ngaya next year.
DELIMITER $$

CREATE EVENT one_time_generate_annual_report
ON SCHEDULE AT '2025-04-02 08:04:00' -- Executes once on January 1, 2026, at 12AM
DO
BEGIN
    DECLARE total_revenue DECIMAL(10, 2);

    -- Calculate total revenue for all payments where payment_status is 'done'
    SELECT SUM(total_amount) INTO total_revenue
    FROM payment
    WHERE payment_status = 'done';

    -- Insert the total revenue into the annual_revenue table
    INSERT INTO annual_revenue (year, total_revenue)
    VALUES (YEAR(CURDATE()), total_revenue);
END$$

DELIMITER ;








INSERT INTO admin (username, password_hash) 
VALUES ('admin1', '$2b$12$YYDJFu2xyuHCqsxfT52inufPQ9asOgIHff2bGkvEkAaClqIMhoSXu');


INSERT INTO owner (username, password_hash) 
VALUES 
('FashionRent_owner', '$2b$12$sH2mYPPoAkJDxIxiTAHkuegZUB49Jbl4FXtByiMyJZx3DBwDDQ7GO'),
('TrendyThreads_owner', '$2b$12$1LJAgSzqKf28K4vd0xw3kOPwEbfe3jXlu1m3D6lEbT3O16EUKdT8u'),
('StyleSwap_owner', '$2b$12$6gQB0VVXorKYgDnUvh9W6.HS13C.apN.6gzrO8Adx1O2XrEEJcKFK'),
('ChicLease_owner', '$2b$12$Yum.C9MuG9gzxwFYPgLhKenz1A5w9Yxq7Y48I7JLb1o81zFycWsMi'),
('GlamGarb_owner', '$2b$12$1NtOXxukPCnXIIp/Tt4uQuJX6QEkHMPJYPojurWdtOxMGH4yj7LJe'),
('Apartment_owner', '$2b$12$6lcnrqD41ezvS8PNYi.4/OCye0y9.VEPeWef4hOnsDEzGCaUJtlKO');


INSERT INTO business (owner_id, name)
VALUES 
(1, 'FashionRent'),
(2, 'TrendyThreads'),
(3, 'StyleSwap'),
(4, 'ChicLease'),
(5, 'GlamGarb'),
(6, 'Apartment');


INSERT INTO employee (full_name, role, email, emp_password, mobile, business_id) 
VALUES 
('Jane Doe', 'manager', 'jane@gmail.com', '$2y$10$3VhwTmi/xiDg8Czs1ROU0OgDxEdtbgwPsoCCULbJJ5SooFgTBMBEq', '09123456789', 1),
('John Smith', 'staff', 'john@gmail.com', '$2y$10$zfLv4wZ.vg4ljkh3lJQxAe0LeUuxP5JnbmPJcb80YoTn8a9Uv8nbG', '09123456790', 1),
('Iron Man', 'staff', 'ironMan@gmail.com', '$2y$10$ufRnXwPKbxPhFaL/9.3xIOUgf5CGeAQpzSPqJmFDFZ9OJVW.Ngp0y', '09123456791', 2),
('Batman', 'manager', 'batMan@gmail.com', '$2y$10$JiEpp5ny5/040e02PD8CNOmJYQGIE8J/dLOr.f8HXOWcfqZaCi1/a', '09123456792', 2),
('Wonder Woman', 'staff', 'wonderWoman@gmail.com', '$2y$10$nCqBFFLcv5lrg4gftwqvsODyrbRTJbKnCIyIlzIZDTZ9SZW71sTsq', '09123456793', 3),
('Spider-Man', 'staff', 'spiderMan@gmail.com', '$2y$10$ilK3viFVbILWgQCnzBPKT.3MC8fhOX9mfS9qpuUzRJZTWwIRU1cxm', '09123456794', 3),
('Superman', 'manager', 'superMan@gmail.com', '$2y$10$L7n/fbcQTM92elWDPm1LbeOqqAduMpI.TX90IYJLjQn9q0SvMkX3W', '09123456795', 4),
('Black Widow', 'staff', 'blackWidow@gmail.com', '$2y$10$etyy.3zk0It8ENWwFqvgpe2ixgWUMf4eBfZxsCL/0IgaF1j1r/55K', '09123456796', 4),
('Thor', 'manager', 'thor@gmail.com', '$2y$10$trfutCoVUmTWPMWLf.AKbulXRRJc2vCKMgh0NU84CbCKL35hmauKC', '09123456797', 5),
('Captain America', 'staff', 'captainAmerica@gmail.com', '$2y$10$8WP65EdoXcXcSfQIaD5Vje2OSoPLo2yR3C3HlO1p33mI2ZhiIFgs.', '09123456798', 5),
('Black Panter', 'manager', 'BlackPanter@gmail.com', '$2y$10$IhJKpNgZR60QfkdcqTtFoOqjRCx2swEY8WFWGKNys/jMaXE.FQDLS', '09123456797', 6),
('Winter Soldier', 'staff', 'WinterSoldier@gmail.com', '$2y$10$wudTlDXiJTBXMQJaURo9tu4TLZkHRoxvZN/3x3Mw9jtTdJPAWMulm', '09123456798', 6);


INSERT INTO product_type (type_name, prd_code)
VALUES 
('TShirt', 'TS'),
('Jeans', 'JNS'),
('Evening Dress', 'ED'),
('Leather Jacket', 'LJ'),
('Skirt', 'SK'),
('Suit', 'ST'),
('Silk Blouse', 'SB'),
('Wool Coat', 'WC'),
('Denim Jeans', 'DJ'),
('Tuxedo', 'TX'),
('Apartment', 'UNIT');


INSERT INTO product (business_id, product_type_id, name, description, base_price, price_unit) 
VALUES 
(1, 1, 'T-shirt', 'Comfortable small-sized T-shirt for casual wear.', 250.00, 'week'),
(1, 2, 'Jeans', 'Slim fit small-sized jeans.', 300.00, 'week'),
(2, 3, 'Evening Dress', 'Elegant evening dress for formal events.', 500.00, 'day'),
(2, 4, 'Leather Jacket', 'Stylish leather jacket for a bold look.', 450.00, 'week'),
(3, 5, 'Skirt', 'Flared skirt for casual and semi-formal occasions.', 200.00, 'week'),
(3, 6, 'Suit', 'Classic suit for professional settings.', 600.00, 'day'),
(4, 7, 'Silk Blouse', 'Luxurious silk blouse for formal events.', 350.00, 'week'),
(4, 8, 'Wool Coat', 'Warm wool coat for winter wear.', 550.00, 'week'),
(5, 9, 'Denim Jeans', 'Relaxed fit denim jeans for everyday use.', 280.00, 'week'),
(5, 10, 'Tuxedo', 'Classic black tuxedo for special occasions.', 800.00, 'day'),
(6, 11, 'Apartment', 'unit space.', 2000.00, 'month');


INSERT INTO inventory (product_id, serial_number, size, status, current_condition) 
VALUES
-- Inventory for Product 1: T-shirt
(1, 'TS1001', 'S', 'available', 'New'),
(1, 'TS1002', 'S', 'available', 'New'),
(1, 'TS1003', 'M', 'available', 'New'),
(1, 'TS1004', 'M', 'available', 'New'),

-- Inventory for Product 2: Jeans
(2, 'JNS1001', 'S', 'available', 'New'),
(2, 'JNS1002', 'M', 'available', 'New'),
(2, 'JNS1003', 'L', 'available', 'New'),

-- Inventory for Product 3: Evening Dress
(3, 'ED1001', 'S', 'available', 'New'),
(3, 'ED1002', 'M', 'available', 'New'),
(3, 'ED1003', 'L', 'available', 'New'),

-- Inventory for Product 4: Leather Jacket
(4, 'LJ1001', 'S', 'available', 'New'),
(4, 'LJ1002', 'M', 'available', 'New'),
(4, 'LJ1003', 'L', 'available', 'New'),
(4, 'LJ1004', 'XL', 'available', 'New'),
(4, 'LJ1005', 'XL', 'available', 'New'),

-- Inventory for Product 5: Skirt
(5, 'SK1001', 'S', 'available', 'New'),
(5, 'SK1002', 'M', 'available', 'New'),
(5, 'SK1003', 'L', 'available', 'New'),
(5, 'SK1004', 'XL', 'available', 'New'),
(5, 'SK1005', 'XL', 'available', 'New'),
(5, 'SK1006', 'XXL', 'available', 'New'),

-- Inventory for Product 6: Suit
(6, 'ST1001', 'S', 'available', 'New'),
(6, 'ST1002', 'M', 'available', 'New'),

-- Inventory for Product 7: Silk Blouse
(7, 'SB1001', 'S', 'available', 'New'),
(7, 'SB1002', 'M', 'available', 'New'),
(7, 'SB1003', 'L', 'available', 'New'),
(7, 'SB1004', 'XL', 'available', 'New'),

-- Inventory for Product 8: Wool Coat
(8, 'WC1001', 'S', 'available', 'New'),
(8, 'WC1002', 'M', 'available', 'New'),
(8, 'WC1003', 'L', 'available', 'New'),

-- Inventory for Product 9: Denim Jeans
(9, 'DJ1001', 'S', 'available', 'New'),
(9, 'DJ1002', 'M', 'available', 'New'),
(9, 'DJ1003', 'L', 'available', 'New'),
(9, 'DJ1004', 'XL', 'available', 'New'),
(9, 'DJ1005', 'XL', 'available', 'New'),

-- Inventory for Product 10: Tuxedo
(10, 'TX1001', 'M', 'available', 'New'),

-- Inventory for Apartment 11: unit
(11, 'UNIT1001', 'one', 'available', 'New'),
(11, 'UNIT1002', 'one', 'available', 'New'),
(11, 'UNIT1003', 'one', 'available', 'New'),
(11, 'UNIT1004', 'one', 'available', 'New'),
(11, 'UNIT1005', 'one', 'available', 'New');


INSERT INTO tenant (full_name, government_id, email, mobile) 
VALUES 
('Alice Brown', 'AB123456', 'alice@gmail.com', '09123456791'),
('Bob White', 'BW123456', 'bob@gmail.com', '09123456792'),
('Charlie Green', 'CG123456', 'charlie@gmail.com', '09123456793'),
('Diana Prince', 'DP123456', 'diana@gmail.com', '09123456794'),
('Edward Norton', 'EN123456', 'edward@gmail.com', '09123456795'),
('Fiona Gallagher', 'FG123456', 'fiona@gmail.com', '09123456796'),
('George Lucas', 'GL123456', 'george@gmail.com', '09123456797'),
('Hannah Montana', 'HM123456', 'hannah@gmail.com', '09123456798'),
('Ian Fleming', 'IF123456', 'ian@gmail.com', '09123456799'),
('Julia Roberts', 'JR123456', 'julia@gmail.com', '09123456800');

INSERT INTO rental_agreement (tenant_id, status, agreed_price, duration, handled_by_employee_id) 
VALUES 
(1, 'active', 250.00, 'week', 1), 
(2, 'active', 300.00, 'week', 2),
(3, 'active', 500.00, 'day', 3),
(4, 'active', 450.00, 'week', 4),
(5, 'pending', 200.00, 'week', 5),
(6, 'active', 600.00, 'day', 1),
(7, 'active', 350.00, 'week', 2),
(8, 'active', 550.00, 'week', 3),
(9, 'pending', 280.00, 'week', 4),
(10,'active', 800.00, 'day', 5),
(1, 'active', 350.00, 'week', 1),
(9, 'active', 2000.00, 'month', 11),
(7, 'active', 2000.00, 'month', 12);

INSERT INTO rental_agreement_details (rental_agreement_id, serial_number_id, check_out_date, returned_date, condition_out, condition_in) 
VALUES 
(1, 'TS1001', '2025-04-02', NULL, 'New', NULL), 
(2, 'TS1004', '2025-04-02', NULL, 'New', NULL),
(3, 'JNS1002', '2025-04-02', NULL, 'New', NULL),
(4, 'ED1002', '2025-04-02', '2025-01-22', 'New', 'Used'),
(5, 'LJ1002', '2025-04-02', NULL, 'New', NULL),
(6, 'ST1001', '2025-04-02', NULL, 'New', NULL),
(7, 'SB1002', '2025-04-02', '2025-02-17', 'New', 'Used'),
(8, 'WC1002', '2025-04-02', NULL, 'New', NULL),
(9, 'DJ1002', '2025-04-02', NULL, 'New', NULL),
(10, 'TX1001', '2025-04-02', NULL, 'New', NULL),
(11, 'SB1001', '2025-04-02', NULL, 'New', NULL),
(12, 'unit1004', '2025-04-02', NULL, 'New', NULL),
(13, 'unit1005', '2025-04-02', NULL, 'New', NULL);





INSERT INTO fee (rental_agreement_id, fee_type, amount, description) 
VALUES 
(12, 'electric', 500.00, 'Electricity bill for 1 month'),
(12, 'water', 300.00, 'Water bill for 1 month'),
(13, 'electric', 400.00, 'Electricity bill for 1 month'),
(13, 'water', 100.00, 'Water bill for 1 month');

-- INSERT INTO payment (rental_agreement_id, total_amount, payment_method, payment_status, reference_number, received_by_employee_id) 
-- VALUES 
-- (1, 250.00, NULL, 'pending', NULL, 1),
-- (2, 300.00, 'bank_transfer', 'done', 'REF12346', 2),
-- (4, 450.00, 'credit_card', 'done', 'REF12348', 3),
-- (5, 200.00, 'bank_transfer', 'done', 'REF12349', 4),
-- (7, 350.00, 'credit_card', 'done', 'REF12351', 1),
-- (8, 550.00, 'bank_transfer', 'done', 'REF12352', 2),
-- (10, 800.00, 'credit_card', 'done', 'REF12354', 4),
-- (11, 350.00, 'credit_card', 'done', 'REF12355', 1);