## Project description

This project was the training material of Cubix Institude of Technology Data Enginieer training. 
It is processing with the daily taxi trips of Chicago City.

## Key components

- Data Source: Chicago Datacenter 
The free API provides taxi trips data. The API updates daily, ensuring the latest information is available.


- Data Extraction and Transformation: Python
The ETL (Extract, Transform, Load) process in Python is responsible for retrieving and transforming the data. The raw data is collected initially, then necessary transformations are performed (e.g., data cleaning, normalization, formatting).

- Data Storage: AWS
Transformed data is stored in the AWS infrastructure. AWS offers a reliable and scalable solution for secure data storage and access.


## Operation
- Data Retrieval
A Python script retrieves the current data from the datacenter every day.


- Data Processing and Transformation
The data is initially collected in raw form. The script cleans and normalizes the data to ensure it is in the correct format for storage and further use.

- Data Storage
The transformed data is stored in AWS. AWS services (e.g., S3, RDS) ensure reliable and scalable data storage.


## Technical implementation

- Programming Language: Python
- API: Electricity API
- Cloud Service Provider: AWS (Amazon Web Services)
- Data Visualization: Power BI
- ETL Tool: Custom Python script

## Future improvements plan

- Power BI visualizations
- Notebook visualizations
- Code refactor
- Implementation of some checking feature