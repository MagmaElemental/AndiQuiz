## Class Diagram

![AndiQuiz Class Diagram](https://github.com/MagmaElemental/AndiQuiz/blob/master/AndiQuiz.Server/ClassDiagram.jpg "AndiQuiz Class Diagram")

### Users

- **Register a new user**

    POST: api/account/register

    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Content-Type | application/json |

    BODY:
    ```js
    {
        "UserName": "testUser"
        "FirstName":"John",
        "LastName":"Doee",
        "Email":"user1@user1.com",
        "Password":"123456",
        "ConfirmPassword":"123456"
    }
    ```
    
- **Get authorization token**

    POST: token

    | Header Key | Header Value |
    |---|---|
    | ContentType | application/x-www-form-urlencoded |

    BODY:
    ```js
    grant_type=password&username=testUser&password=123456
    ```
    
    In order to authenticate to the WebApis that require authorization (have the [Authorize] attribute) you need to provide the received "access_token" as a header "Authorization" of the Http message:

    | Header key | Header value |
    | --- | --- |
    | Authorization | bearer {*your access token here*} |

-   **Get user details**

    GET: api/users/{userName}

    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Authorization | Bearer ...TOKEN |

    BODY:
    ```js
    {
      "UserId": "b15a351d-792e-4bd9-bfad-3181a07116eb",
      "UserName": "testUser",
      "CorrectAnswers": 0,
      "TotalAnswers": 0
    }
    ```
-   **Get Quizzes made by user**

    GET: api/users/{userName}/quizzes?page=1&pageSize=2

    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Authorization | Bearer ...TOKEN |

    BODY:
    ```js
    [
        {
          "Id": 7,
          "Title": "C# Programming 102",
          "CreatedBy": "testUser",
          "CreatedOn": "2016-01-10T02:58:05.85",
          "Rating": "0",
          "TimesPlayed": "0"
        },
        {
          "Id": 6,
          "Title": "C# Programming 101",
          "CreatedBy": "testUser",
          "CreatedOn": "2016-01-10T02:52:33.96",
          "Rating": "0",
          "TimesPlayed": "0"
        }
    ]
    ```

### Quizzes

- **Create new quiz**

    POST: api/quiz

    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Content-Type | application/json |
    | Authorization | Bearer ...TOKEN |

    BODY:
    ```js
    {
        "Title": "C# Programming 102",
        "Category": "IT",
        "Questions": [
            { 
                "QuestionContent": "What is int?",
                "Answers": [
                    {
                        AnswerContent: "an integer",
                        AnswerIs: true
                    },
                    {
                        AnswerContent: "a donkey",
                        AnswerIs: false
                    }
                ]
            },
            {
                "QuestionContent": "What is var?",
                "Answers": [
                    {
                        AnswerContent: "a variable",
                        AnswerIs: true
                    },
                    {
                        AnswerContent: "a car",
                        AnswerIs: false
                    }
                ]
            }
        ]
    }
    ```

- **Rate quiz**

    POST: api/quiz/1/rate

    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Content-Type | application/json |
    | Authorization | Bearer ...TOKEN |

    BODY:
    ```js
    {
        "Rating": 5
    }
    ```
    
- **Get quiz details**

    GET: api/quiz/1

    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Authorization | Bearer ...TOKEN |

    BODY:
    ```js
    {
      "Id": 1,
      "Title": "C# Programming 101",
      "Category": "IT",
      "CreatedBy": "user1@user1.com",
      "CreatedOn": "2016-01-10T01:10:14.48",
      "Rating": 4.5,
      "Questions": 2,
      "TimesPlayed": 2
    }
    ```
    
- **Get all quizzes**

    GET: api/quiz/all?page=1&pageSize=1

    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Authorization | Bearer ...TOKEN |

    BODY:
    ```js
    [
      {
        "Id": 7,
        "Title": "C# Programming 102",
        "CreatedBy": "testUser",
        "CreatedOn": "2016-01-10T02:58:05.85",
        "Rating": "0",
        "Questions": 2,
        "TimesPlayed": "0"
      }
    ]
    ```

- **Get quiz questions**

    GET: api/quiz/1/questions
    
    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Authorization | Bearer ...TOKEN |

    BODY:
    ```js
    [
        {
            "Question": "What is int?",
            "Answers": [
                {
                    "Id": 1,
                    "Content": "an integer",
                    "AnswerIs": true,
                    "QuizQuestionId": 1
                },
                {
                    "Id": 2,
                    "Content": "a donkey",
                    "AnswerIs": false,
                    "QuizQuestionId": 1
                }
            ]
        },
        {
            "Question": "What is var?",
            "Answers": [
                {
                    "Id": 3,
                    "Content": "a variable",
                    "AnswerIs": true,
                    "QuizQuestionId": 2
                },
                {
                    "Id": 4,
                    "Content": "a car",
                    "AnswerIs": false,
                    "QuizQuestionId": 2
                }
            ]
        }
    ]
    ```
    
- **Get quiz score**

    POST: api/quiz/score

    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Content-Type | application/json |
    | Authorization | Bearer ...TOKEN |

    BODY:
    ```js
    {
        "QuizId": 1,
        "AnswersIds": [1,4]
    }
    ```
    
    RESPONSE BODY:
    ```js
    1
    ```

### Categories

- **Get category details**

    **PUBLIC**
    
    GET: api/category/it

    BODY:
    ```js
    [
        {
            "Name": "IT",
            "Quizzes": 7
        }
    ]
    ```
    
- **Get all categories**

    **PUBLIC**
    
    GET: api/category/all
    
    BODY:
    ```js
    [
        {
            "Name": "IT",
            "Quizzes": 7
        }
    ]
    ```
    
- **Get all categories**

    **PUBLIC**
    
    GET: api/category/all
    
    BODY:
    ```js
    [
        {
            "Name": "IT",
            "Quizzes": 7
        }
    ]
    ```

- **Get quizzes for category**

    GET: api/category/it/quizzes?page=1&pageSize=2

    HEADERs:

    | Header Key | Header Value |
    |---|---|
    | Authorization | Bearer ...TOKEN |

    BODY:
    ```js
    [
        {
          "Id": 7,
          "Title": "C# Programming 102",
          "Category": "IT",
          "CreatedBy": "testing",
          "CreatedOn": "2016-01-10T02:58:05.85",
          "Rating": 0,
          "Questions": 2,
          "TimesPlayed": 0
        },
        {
          "Id": 6,
          "Title": "C# Programming 101",
          "Category": "IT",
          "CreatedBy": "testing",
          "CreatedOn": "2016-01-10T02:52:33.96",
          "Rating": 0,
          "Questions": 2,
          "TimesPlayed": 0
        }
    ]
    ```