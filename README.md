# NumBot-ChatGpt API
## Abstract
The purpose of the NumBot application is to output the numbers written with letters in the sentence given by the user as input to the user as written numbers. 
The application is designed on the basis of front-end messaging applications to increase the user experience. In addition, ChatGpt 3.5 Turbo was used for NLP application.

## Overview
NumBot application is designed with MVC and is an ASP .Net project that uses Bootstrap libraries on the front end and RestFul structure on the backend and is written in C# programming language. 
The API designed in the application is designed in a structure that uses the HTTP protocol and only performs POST. Methods can be processed with json and parameter.

## Classes, Methods, and Layers
### Layers
NumBot Application is designed as a single layer. This layer is in MVC structure and has Model, View and Controller sub-layers. 
There are 4 model classes in the Model layer, 1 controller class in the Controller layer, and Home, Particials and Shared folders in the View.
### Classes
There are 4 main classes in the model sublayer. These classes are designed based on requests and returns from the API.
```C#
public class ChatGptGetMessageModel
```
It is the class that represents the data in the json structure from the ChatGpt 3.5 Turbo API.
```C#
public class ChatGptReqModel
```
It is the class that represents the data in the json structure sent to the ChatGpt 3.5 Turbo API.
```C#
public class InputTextModel
```
The class that represents the json data used when sending a request to the NumBot API.
```C#
public class OutputTextModel
```
It is the class that represents the json type data from the NumBot API.
### 
In the application, there is 1 class apart from these layers.
```C#
public class Keys
```
The class that contains the ChatGpt API key. The purpose of creating this class is to store the API key with the .gitignore while sharing the development.
### Methods
Apart from the methods that come standard with ASP .Net, there are 3 methods made for development in the HomeController class. 1 of them is set to private, 2 of them are set to public and the class is encapsulated.
```C#
private async Task<string> AskYourQuestionAsync(string InputText)
```
It is a method that takes 1 parameter and sends a request to the ChatGpt 3.5 API. The parameter named InputText represents the sentence input from the user. The content of the method is as follows.
```C#
public async Task<IActionResult>GetResponse([FromBody] InputTextModel inputText)
```	
It is a POST type async method of NumBot Application that takes 1 parameter of [FromBody] InputTextModel type and receives the sentence input from the user as json, sends the input data to AskYourQuestionAsync method and sends the return value as json.
```C#
public async Task<IActionResult> GetResponseWithParam (string inputText) 
```
It is the type of the GetResponse method used when it is requested to send a request with a parameter in the API. The only difference between the two methods is that while the GetResponse method takes a json parameter, this method takes a string type parameter called inputText.
## API Endpoints and Sample Requests with Postman
### API Endpoints
NumBot uygulamasının API’sinde iki adet EndPoint bulunmaktadır. API’deki EndPoint’ler için herhangi bir yetkilendirme bulunmamaktadır. 
Bunun sebebi projenin, açık kaynak kodlu ve test projesi olarak amaçlanması sebebiyledir. API, herhangi bir sunucuda yayınlanmadığı için şu an local bir sunucuda çalışmaktadır.
EndPoint Address | Headers | Body/Parameters | Response 
| EndPoint Address       | Headers           | Body/Parameters  |  Response  |
| ------------- |:-------------:| -----------:|---------------:|
| https://localhost:XXXX/Home/GetResponse     |Content-Type = application/json | { "UserText":"" }| {"output": ""} |
| https://localhost:XXXX/Home/GetResponseWithParam    | -     |  inputText = ”” | {"output": ""} |

### Sample Requests with Postman
#### GetResponse
![image](https://github.com/basasy/ChatGptChatBot/assets/48106789/9e6d7c12-a63f-4314-955e-8f2e88c9ac45)
![image](https://github.com/basasy/ChatGptChatBot/assets/48106789/b94d2d93-b3e7-4815-a4fd-30291a55a067)
#### GetResponseWithParam
![image](https://github.com/basasy/ChatGptChatBot/assets/48106789/185d601a-84cc-4cef-a502-560bd91b2505)

## User Interface
![image](https://github.com/basasy/ChatGptChatBot/assets/48106789/45baa610-1cc3-457e-9caf-b89bb6c417f2)

On the user side of the NumBot application, the user interface is designed as a messaging interface to increase the user experience. While designing, Bootstrap library was used and additionally CSS, Javascript and Jquery/Ajax methods were used.
The interface is designed with a single Index.cshtml, a View folder named Particials has been added to show the messaging operations, and two .cshtml files representing the sender and the receiver are created and these files are shown as Partials in the Index.cshtml view.
On the right side of the user interface, there is the messaging interface, while on the left side there are links with information about the developer.
![image](https://github.com/basasy/ChatGptChatBot/assets/48106789/ac839311-4611-47aa-99e7-44b1847a39c4)

## Used Technologies
ASP in development. Net framework and MVC design were used, Bootstrap library, HTML, CSS and Javascript programming language and Jquery technologies were used on the front end. On the back end, C# programming language technology was used.


