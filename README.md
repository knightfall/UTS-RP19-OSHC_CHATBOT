
# OSHC Chatbot using Dialogflow

Deliverable of UTS 32933 Research Project Autumn 2019
supervisor: [Dr. Wei Liu](https://www.uts.edu.au/staff/wei.liu)

## What is it

Overseas Student Health Cover is the health insurance which allmost all of the international students in Australia have to purchase before applying for student visa. 
This chatbot intends to educate current and prospective international students in Australia about their OSHC cover, who are the providers and how much do they cost.

## Prerequisites

Cronjob, ScheduleParser and the webhook is written in dotnet core 2.2

To run the chatbot, you will need to have the following

 - [Microsoft .Net Core](https://dotnet.microsoft.com/download)
 - [MySQL](https://dev.mysql.com/downloads/mysql/)
 - [Free Dialogflow account](https://console.dialogflow.com)
### Limitations
- Cronjob fails to run in 1core/1thread droplets in DigitalOcean, probably because of the parallel invoke.
- ScheduleParser isn't tested in linux. You migh face the same issue as Cronjob

## Installation

###  Step 1. Mysql


Have a Mysql instance running. You can use managed Mysql provided by different cloud provider. The demo version of the project uses Google Cloud SQL.
Import the mbs.sql either using Mysql workbench or the following command
```
mysql -u username -p  < mbs.sql //schema name is mbs
```
if something goes wrong, use the create script called create.sql and then use cronjob and ScheduleParser to populate the table
```
create.sql
```
___

### Step 2. ScheduleParser

If you are using the mbs.sql to populate the database, *you can skip this part and start from the next step.*
#### SDK installation
- Download & install your platform version of .Net Core sdk from (https://dotnet.microsoft.com/download)

- Goto ScheduleParser/ScheduleParser
- Open Program.cs
- Replace the values of _servername, _id and _password in the method InserData with your mysql login data.
if you are using the default schema, you don't need to change the value of _catalog.

![Replace values](https://i.imgur.com/q2ohZAb.png)

if your ***schedule*** table isn't empty, run the following command in mysql:
```
truncate mbs.schedule
```
#### Windows with Visual Studio installation
Run the program from ScheduleParser.sln using Visual Studio 2017/2019

#### For Linux and or no Visual Studio installation
In ScheduleParser/ScheduleParser folder,
run in command line:
```
dotnet restore
dotnet run --configuration Release
```
ScheduleParser takes the xml file from ScheduleParser/schedule, parse it and then update it into a database.

-----
### Step 3. Cronjob

Open Cronjob/Cronjob/mbsContext.cs
In method OnConfiguring(),
replace ***xx.xx.xx.xx*** with your server IP, ***root*** with your mysql instance username and ****** with your password.
![Replace values for msyql](https://i.imgur.com/PjOxLg7.png)

#### Windows with Visual Studio installation
Run the program from Cronjob.sln using Visual Studio 2017/2019

#### For Linux and or no Visual Studio installation
In Cronjob/Cronjob folder,
run in command line:
```
dotnet restore
dotnet run --configuration Release
```
it will populate the oshcquote with updated premiums of that time

### Step 4. Webhook
Open webhook\ChatbotAPI\EFModels\mbsContext.cs
In method OnConfiguring(),
replace ***xx.xx.xx.xx*** with your server IP, ***root*** with your mysql instance username and ****** with your password.
#### Windows with Visual Studio installation
Run the program from UTS-ChatBot-RP19.sln using Visual Studio 2017/2019

#### For Linux and or no Visual Studio installation
In webhook\ChatbotAPI\ folder,
run in command line:
```
dotnet restore
dotnet run --configuration Release
```
If everything is alright, it will show this window.
![Running Webhook](https://i.imgur.com/4cNonOI.jpg)

In order to make the webhook work, you will have to have the running instance exposed to the internet with a public IP. The best way to do it is to run it in a cheapo linux instance. For the demo, it is running on a Google cloud compute engine
___
### Step 5. Dialogflow

#### - Create a Dialogflow account
#### - Create a new agent
![creating and agent](https://i.imgur.com/6TtruC2.png)



#### - Go to Export and Import tab in agent settings and click Restore from zip


![restore agent](https://i.imgur.com/Esq0Ouc.png)

#### - Select the chatbot.zip file from your device, type RESTORE and click on the blue RESTORE button.
![uploading and agent](https://i.imgur.com/JR75xVP.png)

#### - Go to fulfillment tab, replace contoso.com with the webhook server ip or domain
![Replacing webhook url with a real one](https://i.imgur.com/GFOlO9c.png)

## Testing the bot

In the Dialogflow console, on the right in ***Try it now***, type
***cost of item 23***
if you have installed everything correctly, it will show:
![mbs item response from dflow](https://i.imgur.com/bVsHWR4.png)

For quotes, try
***26 months no no***
It should show something like this:
![Quote for 26 months single policy](https://i.imgur.com/9xiHap3.png)

### Sample questions

 1. What is MBS?
 2. What is covered?
 3. What is OSHC
 4. Who provides OSHC
 5. Do I need OSHC
 6. Does oshc cover psychiatrist visit?
 7. Does it cover emergency
 8. Get me a quote for OSHC
 9. What is item number X // X can be any integer

## Contact 

If you have any queries, feel free to create an issue or contact me via the email address in my profile.

