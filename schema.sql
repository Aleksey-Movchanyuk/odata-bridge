-- Creating dim_period table
CREATE TABLE IF NOT EXISTS dim_period (
    period_key TEXT PRIMARY KEY,
    period_name TEXT NOT NULL,
    period_order INTEGER
);


-- Creating dim_product table
CREATE TABLE IF NOT EXISTS dim_product (
    product_key TEXT PRIMARY KEY,
    product_name TEXT NOT NULL
);


-- Creating dim_region table
CREATE TABLE IF NOT EXISTS dim_region (
    region_key TEXT PRIMARY KEY,
    region_name TEXT NOT NULL
);


-- Creating fact_sale table
CREATE TABLE IF NOT EXISTS fact_sale (
    id    INTEGER PRIMARY KEY,
    period_key TEXT,
    product_key TEXT,
    region_key TEXT,
    amount REAL,
    count INTEGER,
    FOREIGN KEY(period_key) REFERENCES dim_period(key),
    FOREIGN KEY(product_key) REFERENCES dim_product(key),
    FOREIGN KEY(region_key) REFERENCES dim_region(key)
);

