# EFA Gold Badge Console Application Challenges

#### The files listed in this repository were a part of the Gold Badge final with [Eleven Fifty Academy](https://www.elevenfifty.org/)

#### Each of these five applications utilize the CRUD methodology (create, Read, Update, and Delete) to store and manipulate data. Each application uses these methods in separate and unique ways to accomplish a task. Some of these applications utilize some of these methods and others utilize all of these methods, it just depended on the needs of the challenges. 

#### Each application is organized within three projects: __Console Application__, __Class Library__ and a __Unit Test Project__

### Console Application

#### The Console Application of each project housed the Program and the User Interface of the program. The User Interface acts as the front-end of the application is what the user of each application will interact with to manipulate their data. 

### Class Library

#### The Class Library of each project housed the main class of the application and it's properties, constructors, and fields. The repository is also a class within this library. The repository houses all of the methods used to manipulate certain properties of the main class.

### Unit Test Project

#### The Unit Test Project is used to test all of methods within the repository within test methods. This is crucial to making sure the CRUD and helper methods built within the repository are functioning correctly before we start to construct the user interface

## Challenge 1 - Komodo Cafe

#### Komodo Cafe is an application that allows the manager of a cafe to manage the items on their menu. The manager may use this application to create new menu items with menu names, numbers, descriptions, ingredients list, and a price. Each menu item has a specific identifier "menu number" so that customers can simply say "I'll have a number 6" and the application be able to display the items that make up that menu item. The manager may also delete certain menu items from the overall list of menu items and can view each item.

## Challenge 2 - Komodo Claims

#### Komodo Claims is an application that allows an insurance company to manage claims within their system. The manager has the option to view all existing claims within the system, deal with claims in the list of claims in the queue, and enter a new claim that they receive from a customerto record it within the system. Each claim has a claim ID, a claim type (enum of Car, Theft, or Home), description, amount, incident date, claim date, and measure as to whether or ot the claim is valid depending upon if the claim is within 30 days of the incident date. This application utilizes a queue so that the manager will be able to deal with claims as they arrive and indicates whether or not a claim is valid to the manager. 

## Challenge 3 - Komodo Badges

#### This application was designed to control the different badges issued to personnel within a department and what doors those personnel have access to. Each badge has a name, ID number, and a list of doors that it will grant access to. The manager of this application will be able to initialize new badges, update the doors that are on an existing badge, delete certain doors or all doors on an existing badge, and delete a badge and its doors from the system when security personnel leave their department.This application utilizes a dictionary to store badges and their coprresponding doors with access. The manager will also be able to view all of the badges, their name, and the corresponding doors. 

## Challenge 4 - Komodo Outings

#### This application allows a company to manage and account their company outings. Each outing has a type of outing, either Golf, Bowling, Amusement Park, or Concert, and a number of people that attended the event, the date of the event, the total cost per person to attend the event, and a total cost to produce the outing. The manager of this application will have the ability to view all fo the outings it's company has held, enter a new company outing, and view the total cost for outings held within the last calendar year or all time. This application will assist the company's HR department in recording the moneys spent on certain outings and will help them view certain data, such as attendance, to help them plan more successful outings in the future.

## Challenge 5 - Komodo Greetings

#### The Komodo Greetings application is an enterprise application designed to help companies deal with their email subscription list. Each customer of the company is given a customer type of past, current, or potential to gauge the type of email that should be delivered to them. The application also holds the customer's first and last name and a special email message to be delivered to them. The manager of this application can create new customers and tailor specific messages to that customer. You are also able to view each customer in the system as well as update certain characteristics of each customer. In case a potential customer becomes a current customer after purchasing a product, you can then tailor new emails to that customer based on their updated customer status. You can also remove customers from the system.

### Please feel free to clone and run this repository and reach out to me if you see any room for improvement or areas where we can collaborate together! 
