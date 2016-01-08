## Class Diagram

### Users

- **Register a new user**

    POST api/account/register

    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Content-Type | application/json |

    BODY:
    ```js
    {
        "firstName":"John",
        "lastName":"Doee",
        "email":"user1@user1.com",
        "password":"123456",
        "confirmPassword":"123456"
    }
    ```
- **Get authorization token**

    POST: token

    BODY: x-www-form-urlencoded

    | Header Key | Header Value |
    |---|---|
    | username | *{your emali}* |
    | passwrod | *{your password}* |
    | grant_type | password |

    In order to authenticate to the WebApis that require authorization (have the [Authorize] attribute) you need to provide the received "access_token" as a header "Authorization" of the Http message:

    | Header key | Header value |
    | --- | --- |
    | Authorization | bearer {*your access token here*} |

-
