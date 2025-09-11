Contact Manager Application

Overview

This is an ASP.NET MVC web application for managing contact information. Users can upload a CSV file, view contacts in a table, edit data inline, delete records, and filter/sort the data on the client side.

Features

CSV Upload: Users can upload a CSV file containing the following fields:

  Name [string]

  Date of Birth [date]

  Married [bool]

  Phone [string]

  Salary [decimal]

Data Storage: Contacts are saved in a Microsoft SQL Server database.

Inline Editing: Users can edit table cells directly and save updates to the database.

Delete Records: Each row has a delete button to remove contacts.

Filtering/Search: Live search/filter functionality by any column using a search input.

Sorting: Clickable table headers allow sorting by any column.

Validation: Basic server-side validation ensures correct data parsing.


Notes

Decimal and date parsing uses CultureInfo.InvariantCulture to avoid localization issues.

Ensure CSV uses . as the decimal separator for Salary and yyyy-MM-dd format for Date of Birth.


