import random
from datetime import date, timedelta

# Open file to write SQL
with open('data.sql', 'w') as f:

    # List of car models
    car_models = ['Toyota Camry', 'Honda Accord', 'Tesla Model 3', 'Ford Fusion', 'Chevrolet Malibu', 
                'Nissan Altima', 'Hyundai Sonata', 'Kia Optima', 'Subaru Legacy', 'Volkswagen Passat', 
                'Audi A4', 'BMW 3 Series', 'Mercedes-Benz C-Class', 'Lexus IS', 'Volvo S60', 
                'Infiniti Q50', 'Acura TLX', 'Cadillac CT5', 'Lincoln MKZ', 'Genesis G70', 
                'Alfa Romeo Giulia', 'Jaguar XE', 'Porsche 718 Cayman', 'Chevrolet Corvette', 
                'Ford Mustang', 'Dodge Challenger', 'Nissan 370Z', 'Subaru BRZ', 'Toyota 86', 
                'BMW M2']

    # List of US regions
    us_regions = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California', 'Colorado', 'Connecticut', 
                'Delaware', 'Florida', 'Georgia', 'Hawaii', 'Idaho', 'Illinois', 'Indiana', 'Iowa', 
                'Kansas', 'Kentucky', 'Louisiana', 'Maine', 'Maryland', 'Massachusetts', 'Michigan', 
                'Minnesota', 'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire', 
                'New Jersey', 'New Mexico', 'New York', 'North Carolina', 'North Dakota', 'Ohio', 
                'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island', 'South Carolina', 'South Dakota', 
                'Tennessee', 'Texas', 'Utah', 'Vermont', 'Virginia', 'Washington', 'West Virginia', 
                'Wisconsin', 'Wyoming']

    # Starting date
    start_date = date(2020, 1, 1)

    # Ending date
    end_date = date(2024, 12, 31)

    # Current date
    current_date = start_date

    # SQL for dim_period table
    f.write("INSERT INTO dim_period (period_key, period_name, period_order) VALUES\n")
    order = 1
    while current_date <= end_date:
        # Calculate the week number and year
        week_num = current_date.isocalendar()[1]
        year = current_date.year

        # Create the key and name
        key = f'y{year}_w{week_num}'
        name = f'{year} W{week_num}'

        # Write the SQL command to the file
        f.write(f"    ('{key}', '{name}', {order}),\n")

        # Go to the next week
        current_date += timedelta(days=7)
        order += 1

    # SQL for dim_product table
    f.write("\nINSERT INTO dim_product (product_key, product_name) VALUES\n")
    for i, model in enumerate(car_models, 1):
        # Create the key and name
        key = f'p{i}'
        name = model

        # Write the SQL command to the file
        f.write(f"    ('{key}', '{name}'),\n")

    # SQL for dim_region table
    f.write("\nINSERT INTO dim_region (region_key, region_name) VALUES\n")
    for i, region in enumerate(us_regions, 1):
        # Create the key and name
        key = f'r{i}'
        name = region

        # Write the SQL command to the file
        f.write(f"    ('{key}', '{name}'),\n")

    # SQL for fact_sale table - assuming a random sales amount between 10000 and 50000, 
    # and a random sales count between 20 and 100, for each product in each region in each week
    f.write("\nINSERT INTO fact_sale (period_key, product_key, region_key, amount, count) VALUES\n")
    for period_key in [f'y{year}_w{week_num}' for year in range(2020, 2025) for week_num in range(1, 53)]:
        for product_key in [f'p{i}' for i in range(1, len(car_models)+1)]:
            for region_key in [f'r{i}' for i in range(1, len(us_regions)+1)]:
                sales_amount = 10000 + (50000 - 10000) * random.random()
                sales_count = random.randint(20, 100)

                # Write the SQL command to the file
                f.write(f"    ('{period_key}', '{product_key}', '{region_key}', {sales_amount}, {sales_count}),\n")
