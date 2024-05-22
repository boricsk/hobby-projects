## Project description

This hobby project aims to create a data extraction system that uses the free Electricity API to retrieve current carbon emissions and energy consumption data. The system updates the data every hour and stores it in the Amazon Web Services (AWS) cloud service after transformation. The data processing and transformation are done in Python, while Power BI is used for data visualization.

## Key components

- Data Source: Electricity API
The free Electricity API provides current carbon emissions and energy consumption data. The API updates hourly, ensuring the latest information is available.


- Data Extraction and Transformation: Python
The ETL (Extract, Transform, Load) process in Python is responsible for retrieving and transforming the data. The raw data is collected initially, then necessary transformations are performed (e.g., data cleaning, normalization, formatting).

- Data Storage: AWS
Transformed data is stored in the AWS infrastructure. AWS offers a reliable and scalable solution for secure data storage and access.

- Data Visualization: Power BI
Power BI is used to create visualizations from the data, enabling the monitoring of carbon emissions and energy consumption trends. The visualizations are interactive and customizable, allowing users to easily review and analyze the data.

## Operation
- Data Retrieval
A Python script retrieves the current data from the Electricity API every hour.


- Data Processing and Transformation
The data is initially collected in raw form. The script cleans and normalizes the data to ensure it is in the correct format for storage and further use.

- Data Storage
The transformed data is stored in AWS. AWS services (e.g., S3, RDS) ensure reliable and scalable data storage.

- Data Visualization
Power BI regularly queries the data from AWS and updates the visualizations. Users can interactively explore the charts and reports generated from the current and historical data.

## Technical implementation

- Programming Language: Python
- API: Electricity API
- Cloud Service Provider: AWS (Amazon Web Services)
- Data Visualization: Power BI
- ETL Tool: Custom Python script

## Future improvements plan

- Append the name of the area code to master data
- Production breakdow visualisation
- Refreshing AWS the data from my client machine
- Visualization in the notebooks

Example view of the visualization (Under the Power BI menu):

[Example visualization](https://devnullsec.hu/)