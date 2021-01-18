# TitleApi
This is the backend data and api layer for my Marketplace code.
# Title API
Rest endpoints for all DB entities

# Title Controller
what I actually ended up using. The nested data was needed to reduce the number of calls made by the web app to essentially 1.

#Running TitleApi
Everything should be setup to allow running the app from IDE. 
once running swagger should be available at http://localhost:5005/swagger/index.html

#Notes
Since this is a coding challenge I took a couple shortcuts here I wouldn't normally take. 
    There isn't a config for each pre-prod and prod environment.
    I would normally refactor out all the controllers and services I didn't use.
    The title service is doing all the work.