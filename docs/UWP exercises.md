# UWP exercises

### Contents

[Navigation](#Navigation)  
[Adaptive and responsive design 1](#Adaptive-and-responsive-design-1)  
[Adaptive and responsive design 2](#Adaptive-and-responsive-design-2)  
[Adaptive and responsive design 3](#Adaptive-and-responsive-design-3)  
[User interface controls](#User-interface-controls)  
[Application input 1](#Application-input-1)  
[Application input 2](#Application-input-2)  
[Application lifecycle 1](#Application-lifecycle-1)  
[Application lifecycle 2](#Application-lifecycle-2)  
[Speech recognition](#Speech-recognition)  
[Live tiles and notifications](#Live-tiles-and-notifications)  
[Background agents](#Background-agents)  
[Web view 1](#Web-view-1)  
[Web view 2](#Web-view-2)  
[Map and location 1](#Map-and-location-1)  
[Map and location 2](#Map-and-location-2)  
[Launchers 1](#Launchers-1)  
[Launchers 2](#Launchers-2)  
[Launchers 3](#Launchers-3)  

---

## Navigation
Create an application that contains a main page with a user form containing the following fields:  
- Name
- Last name
- Birth date
- Email

This page has navigation to 2 different pages:
- A page that does not receive any parameter
- A page that receives the information filled in the main form and displays it with a nice format

All pages need to navigate between themselves backward and forward.

---

## Adaptive and responsive design 1
Consider a user object with the following data:
- A picture
- Name
- Last name
- Email
- Phone number

Create an application that contains a list of users showing their name and last name.

When the application is executed from a tablet or desktop and a user selects an item from the list, all the information from the selected item is shown on the side of the list.

When the application is executed from a phone and the user selects an item, the app navigates to a new view that shows all the selected item data and allows calling him/her.

The application keeps a record of how many times a user has been called during the session.

The application needs to adjust itself to the selected theme.

---

## Adaptive and responsive design 2
Consider a user object with the following data:
- A picture
- Name
- Last name
- Email
- Phone number

Create an application that contains a list of users.

The application allows the selection of several users.

If one or more users are selected, a new button is shown that navigates to a view that shows only he selected items.

When on a phone, the selected users are shown on a list and can be called.

When on a desktop, the users can´t be called but their info is shown on a frame similar to that of the WinRT design. 

From the selected users list, if a new user is selected; its picture will be shown with the name. The picture needs to be full screen and adapt to landscape and portrait modes. 

If the application is in landscape mode, the name will be shown on the bottom right corner of the screen. When on portrait mode, it will be shown centered on the top.

If the user has no picture, a default one will be used but it should not be shown full screen.

The application needs to adjust itself to the selected theme.

---

## Adaptive and responsive design 3
Consider a user object with the following data:
- A picture
- Name
- Last name
- Email
- Phone number

Create an application that contains a list of users showing their name and last name inside a combo box.

When an item of the combo box is selected, all the info from the user is shown below the combo box.

The combo needs to adapt its width to that of the screen.

The user info needs to adapt the image to that of the screen on its width value and always show the data below it.

The application needs to adjust itself to the selected theme.

---

## User interface controls
Given a person with the following data:
- A picture
- Name
- Last name
- Birth date
- Gender
- Phone number
- Family members (list of other persons)

Create an application with the following functionality:
- Create a general template that shows the picture of the user with its name and last name in front of it. The picture should not be bigger than 160x120
- The application main view is a hub with the options of creating a new user (from the hub itself), a view with the 5 oldest male persons and a view with the 5 oldest female persons
  - The list with persons allows (both male and female) have a link button that allows navigating to a “tabs and pivot” control (detailed below)
  - When loading the new view, the gender should be selected according to the selection from the hub
- Create a tab and pivot control that groups information by gender and shows in its content a list with the users using the above template
- When a user is selected, it should navigate to a master-detail view that shows the selected user as a master and the list of family members as details
  - This view should adapt to the device by either being side by side or navigation system
  - This view should allow for the user to filter the family members by selecting gender (bottom bar app functionality)
- From the main page it is possible to navigate to a new page with a “nav pane” that shows on the left a list of all the users, ordered by last name
  - The top of the left side list can be filtered by using a search text box and suggests the last name of the users while typing
  - On the right pane, the information of the selected user can be modified
  - When modifying the info, a pop up message is shown to the user asking confirmation
- The application needs to adapt to the device being used and its theme on all views

---

## Application input 1
Given a person with the following data:
- Picture
- Name
- Last name
- Birth date
- Phone number
- Email
- Related contacts

Create an application that shows a list of users, consider:
- The application allows changing the sorting order of the list between last name and user name
- Gestures
  - Two finger tap navigates to the details of the user
- The list view supports semantic zooming
  - When zoomed in, the list of users is shown
  - When zoomed out, the initials are shown

*Extra: Allow the user to rearrange items in the list by dragging and dropping the selected item.*

---

## Application input 2
Given a person with the following data:
- Picture
- Name
- Last name
- Birth date
- Phone number
- Email
- Related contacts

Create an application with a “tab and pivot” controls with two options:
1.	View users
2.	Create user

- The first view should show a list of users which can be filtered by last name
- When a user is selected, it should navigate to a new view showing its information
  - This view, in case of related contacts; should show a nav-pane with the relations
  - The selected user is shown on the content pane
  - This view allows calling the user
  - In case of related contacts; when selecting the call function, a list of phones should be shown for the user to select the desired one
- The second view should show a form that allows the creation of new users
- The second view allows marking two or more users as being the same one
- All fields should show its correct input scope

---

## Application lifecycle 1
Create an application with 3 views that can navigate between themselves.

Each navigation process shows in the view the place in the navigation history.

When the application is suspended, the whole navigation history should be stored.

When the application is resumed, the whole navigation history should be available to navigate (backward and forward).

---

## Application lifecycle 2
Given a person with the following data:
- Picture
- Name
- Last name
- Gender
- Phone number
- Family members

Create an application with a hub, considering:
- The hub sections filter by the following criteria
  - A random user being shown by its picture on the whole hub item
  - No family members
  - 2-5 members
  - 5+ members
  - Male members
  - Female members
  - All persons
- When selecting a user, it navigates to its details
- The hub controls allow showing/hiding hub sections
- If the application is suspended, the navigation needs to be stored
- If the application is suspended, the section visibility needs to be stored
- Restoring the app allows full navigation and settings restoration

---

## Speech recognition
Create an application that contains 3 views:
- A list of employees
- The creation screen for employees
- A landing page

Navigation is allowed between the 3 views.

Add speech recognition so that [Cortana](https://support.microsoft.com/en-us/help/17214/cortana-what-is) may load any of the 3 views by voice recognition.

---

## Live tiles and notifications
Create an application with a list of users with picture, name, last name, birth date and phone number.

When the application loads, it should notify the user with a toast message of whoever has its birthday on the day of the execution.

The primary tile should always show the info of the next birthday. 

The application can make phone calls to any person from the list.

The application allows creating secondary tiles for every person in the list. When selecting one of these tiles, the OS will call him instead of opening the app.

*Extra: The app should show so as a badge the number of birthdays on the executing date.*

---

## Background agents
Create an application that, once a minute; shows a toast notification to the user asking for user input.

The application needs to show the input the user introduced on the toast notification.

---

## Web view 1
Implement an application that allows the user to navigate through the internet.

The application needs to store the last 5 pages (both forward and backward) to which the user navigated to in case of suspension.

Allow the user to store its 3 favorite websites so that they are available every time the app runs.

---

## Web view 2
Create an app that allows the user to navigate on internet.

The application should allow the user to pin its favorite websites as secondary tiles which, when executed, load the desired site.

Every time a site is loaded, the app should vibrate a random number of seconds when running on a phone.

---

## Map and location 1
Create an app that stores the geolocation coordinates of the user every minute.

The app should show:
- A list of the coordinates where the user has been
- Equal coordinates are shown once
- The total amount of registered locations should be shown

---

## Map and location 2
Create an app that stores the geolocation coordinates of the user every minute.

The app should show: 
- A list of the coordinates where the user has been
- Similar coordinates are shown once
- The total amount of registered locations should be shown

The location should estimate a radius of 100 meters for similar locations.

---

## Launchers 1
Create an application that shows a map with the current location of the user.

From inside the app, the zoom level of the map should be configured.

---

## Launchers 2
Create an app that allows the user to set a series of coordinates.

The app should then show a map with all the coordinates introduced by the user marked on it.

The user should be able to access a GPS route with the coordinates introduced.

---

## Launchers 3

Create an application that is used to solve simple mathematical formulas.

At any point, the application should be able to open a calculator, solve a simple operation and receive the result to continue with the calculation.
