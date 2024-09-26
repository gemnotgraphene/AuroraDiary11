# Project
# INFT6009 Cloud Computing and Mobile Applications for the Enterprise

## Description

Aurora Diary is an application designed to help users in capturing and preserving some very invaluable memories and great information. Aurora Diary allows users quickly to jot down notes and save essential details, write full diary entries if so desired, and attach photos for a more personalized experience. It helps one to easily capture life’s events. Aurora Diary will be nice for just recording, writing down some critical information, or reflecting on it. With the above features, Aurora Diary becomes an extremely useful tool for anyone who intends to preserve their life journey in some meaningful, organized way.

## Project Planing

### 1. Storyboards
#### User Login/Registration Flow:
The application starts with a login page. A user logs in with their credentials or passes on to the next page for registration in a case they do not have an account. On the run, a registration page is where one creates a new account, details as necessary. On successful login or registration, it will redirect directly to the main diary entry list, where all entries are displayed abreast and manipulated. Safe exposure of personal information; easy segue into the core functionality of the app to enhance user experience.

![ResLogForgot Screen](AuroraDiary11/Resources/Images/ResLogForgot.png)

#### Main Diary Entry Flow

The home page contains a list of all the entries made by a person. Each specific entry is represented with its title, date, emotion linked to it, and an optional photo, giving the user an idea of the entries. Each entry expands upon tapping, showing details: it displays before the users the whole content of that entry and the attached photo. This expanded view also allows the user to edit or delete the entry.
A "Add New Entry" button can be clicked for navigation to a form where the title and content of the entry are taken, an emotion is selected, a new photo to be taken, or an existing one from their gallery can be uploaded.

![Entry](AuroraDiary11/Resources/Images/Entry.png)

Editing an existing entry is also done by a similar process: the users will be allowed to edit the title, text, or emotion, or replace the picture. If a user wants to delete an entry, the user can do it only from the expanded view that appears immediately after confirmation of such action.

![AllEntry](AuroraDiary11/Resources/Images/AllEntry.png)

It has an intuitive design, ensuring that all interactions are smooth and transcendent. Moreover, the user’s experience will be significantly enhanced. Making use of SQLite for local storage of entries, it backs up data between sessions in a lightweight yet secure form.

#### Adding/Editing Diary Entries

A user can add/edit diary entries by specifying a title, content, and choosing an emotion. They can attach a photo to their entry. They are able to either take a new picture using the Camera of the device or use the pictures that already exist in their Galleries for attaching photos. This is the flexible way to ensure that users can capture and document their moments easily that enable them to create content with visuals in diary entries. The intuitive interface guides in loading and updating personal diary entries.

![selectEmotion](AuroraDiary11/Resources/Images/SelectEmotion.png)

#### Settings

The users can change Personal Detail, Notification Modes and Logout.

![Setting](AuroraDiary11/Resources/Images/Settings.png)

### 2. Data Management

It uses a dual-database system to deal with different aspects of data management.

![SQLite](AuroraDiary11/Resources/Images/SQlite.png)

SQLite: This light, embeddable database is used for local storage of diary entries in the User’s device. This will ensure that users can log and self-manage their entries offline.

![Firebase](AuroraDiary11/Resources/Images/Firebase.png)

Firebase: Firebase Authentication is used for user authentication and saving users that log in to application securely. This will ensure fluent, secure login across devices.
These will provide a robust and secure foundation for the AuroraDiary application with models and database systems combined, making sure of data integrity, security, and convenience in use.

### 3. Feature Set and Sensors
#### Camera Integration:
The Aurora Diary app is capable of taking photos with a device’s camera, saving these captured memorable moments, and then uploading them directly to entries. This would provide users with the capability to document their experiences in a visual form, making the entries more lively and personal.
#### Image Upload:
It allows a facility to choose an existing picture from the device gallery and attach it against any entry. This flexibility would let users enrich their entries with photos taken at various times and places, adding a third dimension to their documentation.
Firebase Authentication: User registration and login are done with the help of Firebase Authentication. It provides secure authentication that allows users to create an account and log in while showing entries across multiple devices. Firebase ensures robust security features for protecting data while ensuring user privacy.

### 4. SQLite Database

It uses SQLite that is a very efficient database that allows a user to access and manage their diary entries offline. In this way, one is guaranteed to continue writing and reviewing his or her entries without the need to have an internet connection all the time.
#### Sensor and Hardware:
Camera: Another important device feature is the camera, which can be used to take pictures, send them along with a diary entry, and enhance an app’s functionality where one can make captures from within the app itself.

Storage: Images and diary entries are stored and retrieved within local storage. Thus, all data-whether in the form of photos or text-based entries are very accessible to the user for a smooth and reliable user experience.
 ### 5. Demonstration Video

 Youtube (https://youtu.be/4Iu-UaO39EE?si=BlJmh9rt4tKyMj4T)

## Assessment Results

![AssessmentResuls](AuroraDiary11/Resources/Images/Results.png)