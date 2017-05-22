# Hello World Movies

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/244456c7ca5b449eb9396a3db933cf07)](https://www.codacy.com/app/rohan.buchner/Movies?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=rohan-buchner/Movies&amp;utm_campaign=Badge_Grade)

**Technology Used**

Serverside:
  * .Net (Platform)
    *  WebAPI 
    *  Nunit
    *  Rhino Mocks
    *  Ninject
    *  EF6 ORM

Clientside:
  * AngularJS
  * Bootstrap
    *  Built from SCSS sources
    
Architecture:
  * MVC
  * Repository Pattern
  * Code First
  * Dependency Injection
    
Concepts / Application flow:
Hybrid application, single server side constructed page that enables us to make use of the .NET bundling to deliver the initial payload, after which the front end SPA app intracts with the API. This enables us to potentially have multiple "dumb" front end apps, in whatever language living on the same domain, as long as each has its own new entry point.

Real world use case:
Login or thin extrenal app, but once logged in we make use of .NET auth to validate the user, then redirect to a bigger "internal" app. Thus decreasing payloads for users who don't have the full app access (or need it). The same principal can apply to a permission level where we can conditianlly serve only code that someone is authorized to see.
