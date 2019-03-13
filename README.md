# _HairSalon.Solution_

#### _Hair Salon website for Epicodus, 3.10.2019_

#### By _**Young Liu**_

## Description

_This website allows you to manage stylists and clients in a hair salon._

## Specifications

* _Website will allow user to hire a stylist._
  * _Example input: Click "Add a stylist" button, enter in details._
  * _Example output: Stylist will be added to the hair salon._
* _Website will allow user to add a client to a stylist._
  * _Example input: Click on a stylist, click "Add a new client to this stylist" and enter details._
  * _Example output: Client will be added to that stylist._
* _Website will show all stylists._
  * _Example input: Click on "view all stylists" link or "See all stylists" button._
  * _Example output: All stylists are displayed._
* _Website will show all clients belonging to a stylist, and the stylist's details._
  * _Example input: Click on a stylist's name._
  * _Example output: Page is displayed showing the stylist's details and clients._
* _Website will show the details of a client._
  * _Example input: Click on a client's name._
  * _Example output: Page is displayed showing the details of the client._
* _Website will allow you to edit the details of a client._
  * _Example input: Click on a client's name, then click on "Edit this client"._
  * _Example output: Page is displayed with a form allowing you to edit the details of a client._
* _Website will allow you to clear all stylists._
  * _Example input: Click on the "Clear all stylists" button._
  * _Example output: All the stylists will be cleared._
* _Website will allow you to clear a specific stylist._
  * _Example input: Click on a stylist in the home page, and then click delete this stylist._
  * _Example output: The stylist will be deleted._
* _Website will allow you to clear all clients._
  * _Example input: Click on see all clients in main page, and then click on delete all clients._
  * _Example output: All clients will be deleted._
* _Website will allow you to clear a specific client._
  * _Example input: Click on a clients name in either the client overview, or when listed under a stylist. Then click delete this client._
  * _Example output: The specified client will be deleted._
* _Website will allow you to view all clients._
  * _Example input: Click on see all clients in the main page._
  * _Example output: All clients will be displayed._
* _Website will allow you to edit the details of a stylist._
  * _Example input: Click on a stylists name, then click on edit this stylist._
  * _Example output: The specified stylist will have their details edited._
* _Website will allow you to edit the details of a stylist._
  * _Example input: Click on a stylists name, then click on edit this stylist._
  * _Example output: The specified stylist will have their details edited._
* _Website will allow you to view all specialties._
  * _Example input: Click on see all specialties in the main page._
  * _Example output: All specialties will be displayed._
* _Website will allow you to add a specialty._
  * _Example input: Click on see all specialties in the main page, then click add a specialty._
  * _Example output: Gives a form allowing you to create a specialty._
* _Website will allow you see stylists who have a certain specialty._
  * _Example input: Click on a specialty in the specialty overview page or when listed under a stylist._
  * _Example output: The website will display a page showing which stylists have that specialty._
* _Website will allow you see the specialties of a specific stylist._
  * _Example input: Click on a stylist._
  * _Example output: The website will display their info page, which includes what specialties they have._
* _Website will allow you see stylists who have a certain specialty._
  * _Example input: Click on a specialty in the specialty overview page or when listed under a stylist._
  * _Example output: The website will display a page showing which stylists have that specialty._
* _Website will allow you to add a specialty to a stylist._
  * _Example input: Click on a stylist, then select a specialty in the dropdown menu._
  * _Example output: The specified specialty will be added to the stylist._
* _Website will allow you to add a stylist to a specialty._
  * _Example input: Click on a specialty in the specialty overview page or when listed under a stylist, then select a stylist in the dropdown menu._
  * _Example output: The specified stylist will be added to the specialty._


## Setup/Installation Requirements

* _Download .NET Core 1.1.4 SDK, .NET Core Runtime 1.1.2 and MAMP and install them._
* _Clone this Repository ($ git clone https://github.com/youngzliu/HairSalon.Solution name)_
* _Import young_liu.sql and young_liu_test.sql_
  * _Navigate to you phpMyAdmin page from the Open Webstart page of MAMP._
  * _Select the Import tab._
  * _Select both of the above databases._
* _Change into the work directory ($ cd HairSalon.Solution)_
* _To edit the project, open the project in your preferred text editor._
* _To run the website, navigate to the directory of HairSalon, and then build and run ($ cd HairSalon;
  $ dotnet restore; $ dotnet build; $ dotnet run)_
  * _Then navigate to http://localhost:5000 on your browser of choice._
* _To run the tests, use these commands: $ cd HairSalon.Tests $ dotnet restore $ dotnet test_
* _To recreate the database, run these commands:_
  * >CREATE DATABASE young_liu;
  * >USE young_liu;
  * >CREATE TABLE clients ID serial PRIMARY KEY, firstName VARCHAR(255), lastName VARCHAR(255), phoneNumber VARCHAR(255), email VARCHAR(255), stylistID int;
  * >CREATE TABLE stylists ID serial PRIMARY KEY, firstName VARCHAR(255), lastName VARCHAR(255) phoneNumber VARCHAR(255), email VARCHAR(255);
  * >CREATE TABLE specialties ID serial PRIMARY KEY, description VARCHAR(255);
  * >CREATE TABLE stylists_specialties ID serial PRIMARY KEY, stylist_ID VARCHAR(255), specialty_ID VARCHAR(255);

## Support and contact details

_For support find me at Epicodus._

## Technologies Used

_This website was created using C#, .NET Core, MSTest, ASP.NET Core MVC, SQL, and MAMP._

### License

*MIT License*

*Copyright (c) 2019 Young Liu*

*Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:*

*The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.*

*THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.*
