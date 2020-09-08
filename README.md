# 2SHARE DEVELOPMENT ASSESSMENT - LUIS ALEJANDRO ZULETA

1. __2SHARE - BACKEND__

1.1. __CLONE THE REPOSITORY AND BUILD THE PROJECTS:__

1.2. __CONNECTION STRING:__ 

If you dont want to use a MSSQL local database change the connection string in `App.config` file in the `2Share/DataAccess` project. Also if you use a dedicated database server you will have to create the database objects to run the project. Use the scripts below:
```
readme_files/GroceryList.sql
readme_files/Product.sql.sql
readme_files/ProductGroceryList.sql
```

1.3. __RUN THE STARTUP PROJECT__ `2Share`. If an error occurs while running the project the first time use this command to refresh the solution and config files to the compiler in your machine.

`Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r`

![Alt text](https://github.com/azuletag/2share/blob/master/readme_files/apirunning.png?raw=true "Optional Title")

1.4. __CONSUME THE API.__

DATA: AVAILABLE PRODUCTS\
METHOD: GET\
ENDPOINT: /api/grocery/products\
RESPONSE: JSON
```
[
    {
        "ProductID": 1,
        "Name": "Apples"
    },
    {
        "ProductID": 2,
        "Name": "Bananas"
    },
    .
    .
    .
]
```

DATA: GROCERY LIST\
METHOD: GET\
ENDPOINT: /api/grocery/\
RESPONSE: JSON
```
{
    "Products": [
        {
            "Product": {
                "ProductID": 1,
                "Name": "Apples"
            },
            "ProductID": 1,
            "GroceryListID": 1,
            "Tagged": false
        }
    ],
    "GroceryListID": 1,
    "Name": "My Grocery List"
}
```
DATA: GROCERY LIST\
METHOD: POST\
ENDPOINT: /api/grocery/\
RESPONSE: JSON\
BODY:JSON
```
{
    "GroceryListId" : 1,
    "Products": [
        {
            "ProductId" : 1,
            "Tagged": 0
        },
        {
            "ProductId" : 1,
            "Tagged": 0
        }
        .
        .
        .
    ]
}
```
2. __2SHARE - FRONTEND__

2.1. INSTALL NODEJS https://nodejs.org/

2.2. INSTALL VUE CLI 

From a terminal run `npm install -g @vue/cli`

2.3. __CHANGE ENDPOINTS URL__: Go to the the file `2Share\2share-frontend\.env.development` and edit it to set the variables values that suite your environment backend URLS.

2.4. __RUN THE APPLICATION.__ in the the same folder `2Share\2share-frontend\` run the command `npm run serve`.

![Alt text](https://github.com/azuletag/2share/blob/master/readme_files/frontend-running.png?raw=true "Optional Title")

You can also deploy the built version from `2Share\2share-frontend\dist` folder but you will have a web server with network access to the backend server.

__DEMO:__

![Alt text](https://github.com/azuletag/2share/blob/master/readme_files/demo.gif?raw=true "Optional Title")









