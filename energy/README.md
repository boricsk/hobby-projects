## Project description

This hobby project aims to create a data extraction system that uses the free Electricity API to retrieve current carbon emissions and energy consumption data. The system updates the data every hour and stores it in the Amazon Web Services (AWS) cloud service after transformation. The data processing and transformation are done in Python, while Power BI is used for data visualization.

## Key components

- Data Source: Electricity API
The free Electricity API provides current carbon emissions and energy consumption data.<br>
The API updates hourly, ensuring the latest information is available.


- Data Extraction and Transformation: Python
The ETL (Extract, Transform, Load) process in Python is responsible for retrieving and transforming the data.<br>
The raw data is collected initially, then necessary transformations are performed (e.g., data cleaning, normalization, formatting).

- Data Storage: AWS
Transformed data is stored in the AWS infrastructure.<br>
AWS offers a reliable and scalable solution for secure data storage and access.

- Data Visualization: Power BI
Power BI is used to create visualizations from the data, enabling the monitoring of carbon emissions and energy consumption trends.<br>
The visualizations are interactive and customizable, allowing users to easily review and analyze the data.