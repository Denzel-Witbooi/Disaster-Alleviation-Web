# Disaster Alleviation Website
![image](https://github.com/Denzel-Witbooi/DisasterReliefWebApp/assets/77748858/1cf976cb-3aa9-49bf-875d-2fa9ef82a35a)

## About the project
This project is from my APPLIED PROGRAMMING module - [Demo](https://youtu.be/nUPYDKHNbQI)

## Tech Stack
**Client**: HTML, C# (ASP.NET 5 + Identity), CSS, Bootstrap

**Server**: Azure SQL, Azure Devops, Azure App Services

## Features
- Users can log in securely to the web application and edit information.
- Users can make monetary and goods donations.
- Users can choose whether to donate publicly or anonymously.
- When donating goods, users can select from pre-configured categories or make their own.
- Users can load new disasters on the system.
- Non registered users, can view pages showing them the:
  -   Total monetary and goods donations received.
  -   Currently active disasters, with all donations allocated to them.
 
# Disaster Alleviation Foundation

The Disaster Alleviation Foundation, a non-profit organisation, has approached you to build a system for them. The foundation’s mission is to provide practical aid during disasters. They receive donations from various sources and need a system to track what is available and what has been dispatched to help with which disaster.

Donations can be made by individuals, companies, other organisations, and even governments. Donations can be goods (clothes, non-perishable foods, etc.) or monetary. Donors can choose to remain anonymous.

The Disaster Alleviation Foundation then needs to track what happens with the donations. For example, goods can be dispatched to help with a disaster. Money can either be paid out (for example, to a local community organisation) or used to purchase goods that are then dispatched to a disaster area.

The Disaster Alleviation Foundation has transparency as one of its core values. It is important to them that the collected data is accurate and always available to the right stakeholders. That is why they want a web application with some pages visible to everyone, with summarised information, and other pages accessible only to their employees (for editing data).

## Requirements

1. The web application must use the colour scheme of the foundation – purple and orange.
2. Users must log in securely to the web application to be able to edit information.
3. The web application must allow authorised users to capture new monetary donations. The date and amount are mandatory, but the donor may decide to remain anonymous.
4. The web application must allow authorised users to capture new goods donations. The date, number of items, category, and description of each item are mandatory. But the donor may decide to remain anonymous.
5. The web application must be pre-configured with the following categories of goods:
   - Clothes
   - Non-perishable foods

6. The web application must allow authorised users to define new categories of goods.
7. The web application must allow authorised users to capture a new disaster. The data for a disaster includes the start date and end date, the location, and a description. It must also be possible to specify the required aid types, such as water provision, clothing, food, etc.
8. The web application must allow authorised users to view the following lists:
   - All incoming monetary donations
   - All incoming goods donations
   - All disasters

9. The web application must allow authorised users to allocate money to an active disaster. (Part 2 and PoE only)
10. The web application must allow authorised users to allocate goods to an active disaster. (Part 2 and PoE only)
11. The web application must allow authorised users to capture the purchase of goods using available money. This means that the available money decreases, and the goods are added to the inventory of available goods and allocated to a specific disaster. (Part 2 and PoE only)

12. The web application must have a publicly accessible page that shows the following information (PoE only):
   - Total monetary donations received
   - Total number of goods received
   - Currently active disasters, with the money and goods allocated to the disaster.

[Note: 1 Fictional organisation. Any resemblance to a real organisation is purely coincidental.]

© The Independent Institute of Education (Pty) Ltd 2022

[Previous .NET 5 Project](https://github.com/Denzel-Witbooi/DisasterReliefWebApp)

