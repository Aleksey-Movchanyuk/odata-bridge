-- Creating time_dim table
CREATE TABLE IF NOT EXISTS time_dim (
    key TEXT PRIMARY KEY,
    name TEXT NOT NULL
);


-- Creating product_dim table
CREATE TABLE IF NOT EXISTS product_dim (
    key TEXT PRIMARY KEY,
    name TEXT NOT NULL
);


-- Creating region_dim table
CREATE TABLE IF NOT EXISTS region_dim (
    key TEXT PRIMARY KEY,
    name TEXT NOT NULL
);


-- Creating sales_fact table
CREATE TABLE IF NOT EXISTS sales_fact (
    period_key TEXT,
    product_key TEXT,
    region_key TEXT,
    sales_amount REAL,
    sales_count INTEGER,
    FOREIGN KEY(period_key) REFERENCES time_dim(key),
    FOREIGN KEY(product_key) REFERENCES product_dim(key),
    FOREIGN KEY(region_key) REFERENCES region_dim(key)
);

