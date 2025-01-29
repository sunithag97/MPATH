MPath Patient Management Portal


## Introduction
This project is a web application that allows patients to manage their medical records and appointments. It is built using the Angular and dotnet core 8 and is designed to be user-friendly and easy to navigate. The application allows patients to create an account, log in, and view their medical records and upcoming appointments. Patients can also schedule new appointments and update their personal information. The application is secure and HIPAA-compliant, ensuring that patient data is protected at all times.

### Documentation
## Features
- User-friendly interface
- Secure login and logout
- Add Patient For Admin
- Mark Recommendations by [patient]
- Audit log

## Technologies
- Angular
- dotnet core 8
- HTML
- CSS
- Entity Framework Core
- SQL Server
- Bootstrap
- JWT
  
## Security
Authentication: JWT (JSON Web Tokens)
Description: The application uses JWT for secure authentication. Tokens are generated upon user login and are used to authenticate subsequent requests. HTTPS is used to encrypt data transmitted between the client and server.

## Audit Logging
Description: The application includes an audit logging mechanism to track patient interactions. This ensures that all actions performed by users are logged for security and compliance purposes.

# Architecure
![image](https://github.com/user-attachments/assets/d33c37c7-9730-4dc3-9104-31e1b1a30587)

## Installation Angular
To install the application, follow these steps:
1. Clone the repository
2. Run `npm install` to install the necessary dependencies
3. Run `ng serve` to start the development server
4. Navigate to `http://localhost:4200/` to view the application
5. Log in to get started

## Installation dotnet core 8
To install the application, follow these steps:
1. Clone the repository
2. Run `dotnet restore` to install the necessary dependencies
3. Run `dotnet run` to start the development server

## Database
The application uses a SQL database to store patient information. The database schema is as follows:
- Refer to the mPathDB.sql file to create local database
- Patients
  - ID (int, primary key)
  - Name (string)
  - DateOfBirth (string)
  - Gender (string)
- Recommendations
  - ID (int, primary key)
  - PatientID (int, foreign key)
  - Type (string)
  - Description (string)
- AuditLogs
  - ID (int, primary key)
  - PatientId (int)
  - Action (string)
  - Date (datetime)
- Recommendation Types
  - ID (int, primary key)
  - Key (string)
  - Description (string)

## Swagger Documentation

![image](https://github.com/user-attachments/assets/fb32d87a-9bdb-4d75-a4d4-a174dd608146)

## Application Screenshots


### Login Page

users details:
- admin/password
- healthcare/password

![image](https://github.com/user-attachments/assets/060feaf6-7ae4-48fb-9218-4716b3529a03)


### Patient Dashboard

![image](https://github.com/user-attachments/assets/fafedd5e-0ff9-4c07-ab60-06da70e9fd6a)


1. Upon Login, the user is redirected to view patients list
2. Admin can add new patient
3. Logout button is available to logout
4. Clicking on patient name will open modal to patient details and recommendations 
5. Recommendations can be added by clicking check box 
6. Audit log is stored in the database on each action add/update 
7. Pagination is available to view more patients 
8. Search bar is available to search patients by name or id 
9. Appointments screen is available and is blank for now 
10. Page is responsive and can be viewed on mobile devices 
11. Page is secure and only accessible after login 
12. Page is rendered by components and services

### Add Patient
![image](https://github.com/user-attachments/assets/9ddd9628-ca66-49a6-8812-1ce356d952b9)

1. Admin can add new patient by clicking on add patient button
2. Add button is validated if fields are empty
3. Date of birth is validated to be in the past
4. Gender has to be selected from dropdown

### Nav bar
1. Collapse button is available to view menu on mobile devices
2. Can expand and collapse menu


# Deployment Process

# Angular
# Build the Docker image
docker build -t mpathui .

# Run the Docker container
docker run -d -p 80:80 mpathui

# dotnet core 8

# Build the Docker image
docker build -t mpathapi .

# Run the Docker container
docker run -d -p 5000:80 mpathapi









