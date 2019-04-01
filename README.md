# Example Issue Tracker Application

The Example Issue Tracker Application (EITA) **consolidates** recent posts from different social media platforms, based on tag/hashtag, and allows them to be turned into **categorized** tracked issues. These tracked issues can be associated to JIRA bugs/stories for convenient organization of problems and solutions.  

## Getting Started

EITA is an ASP.net WebForms application, built in VisualStudio 2017, targeting .net 4.5. All external libraries used are included in the repo with the exception of Newtonsoft.Json, which is included in the .net framework. 

### Prerequisites

Required Software:

```
Windows 10 with .net 4.5 installed.
VisualStudio 2017 or later. Community edition is supported. 
Twitter developer account https://developer.twitter.com/ with registered app
Stack Apps registered app https://api.stackexchange.com/docs
```

### Installing

A step by step series of examples that tell you how to get a development environment running

Download or clone the EITA repository 

```
https://github.com/nickgamb/eita.git
```

Open EITA.sln in Visual Studio

Open web.config and modify appSettings for your environment
 * **oAuthComsumerKey:** Consumer key from Twitter registered app
 * **oAuthComsumerSecret:** Consumer secret from Twitter registered app
 * **searchQuery:** Twitter hashtag list https://developer.twitter.com/en/docs/tweets/search/guides/standard-operators
 * **stackAppKey:** Application key from registered stack app
 * **stackTags:** A semicolon delimited list of tags

```
<appSettings>
    <add key="oAuthConsumerKey" value="myTwitterKey" />
    <add key="oAuthConsumerSecret" value="myTwitterSecret" />
    <add key="oAuthUrl" value="https://api.twitter.com/oauth2/token"/>
    <add key="timelineFormat" value="https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&amp;include_rts={1}&amp;exclude_replies={2}&amp;count={3}"/>
    <add key="screenname" value="screenname"/>
    <add key="include_rts" value="1"/>
    <add key="exclude_replies" value="0"/>
    <add key="count" value="5"/>
    <add key="searchFormat" value="https://api.twitter.com/1.1/search/tweets.json?q={0}"/>
    <add key="searchQuery" value="%23myhashtag" />
    <add key="stackAppKey" value="myStackAppKey"/>
    <add key="stackTags" value="mytag;anotherTag" />
  </appSettings>
```

Run locally via IIS Express by pressing debug, or F5.

## Usage

With the site up and running locally, the Feed page is now populating with recent posts relevant to the tags configured in the web.config

### The Feed

The **Feed** is where a **consolidation** of recent posts will appear for all supported social media sources. Posts can then be tracked by clicking the "Track" button. Once tracked, the posts are written to the tracking.json file, stored locally, and are then viewable in the Tracking menu. Upon clicking "Track", the user will be asked to provide a **category** for the issue which is written to the tracking.json file. 

The Feed includes the following information:

```
Username: Username of the original poster.

Description: Body of the post.

Tags: All tags/hastags in the post.

Source: What social media source that the post originated from.

Post ID: The unique ID given to the post by the source platform

```
* **Important :** Post ID is used as the unique, immutable, ID for storage in the local JSON file.

### Tracking

The **Tracking** menu is where all tracked issues are displayed. Tracked issues can be deleted, associated to a JIRA bug/story, categorized, and replied to using the buttons in the Actions column.  

Tracking includes the following information:

```
Action: Buttons to Reply, Add a JIRA ID, Add a Category, and Delete.

Username: The username of the original poster.

Description: The body of the post.

Source: The social media source of the post.

GUID: Ths unique, immutable, ID for the issue.

JIRA: Associated JIRA bugs/stories

Category: The category of the issue. 
```
## Adding New Sources

EITA is designed with extensibility in mind. The IntuitDemoLib handles all data source implementations in DataSouces.cs. The **Posts** class object represents the expected shape of each post once parsed and the **PostResults** list is a list containing many Post class objects and is a consolidation of all posts form all sources. 

```
    public class Posts
    {
        public string Name { get; set; }
        public string PostText { get; set; }
        public string Category { get; set; }
        public string Source { get; set; }
        public string GUID { get; set; }
    }
```
To add a new data source:
* Start by creating a new function which will get posts from the source, parse each post into a Posts class object and add the objects to the PostResults list. 
* Below is the Stack Overflow function as an example. 
```
• The function accesses the Stack Overflow API's 
• Gets a json payload of posts
• Deserializes the json into an object
• Loops through the object to access the data used by EITA in each post
• Populates each post into a Posts class object
• Adds the Posts class object to the PostResults list which is a consolidated list of all posts from all sources.
```

```
	/// <summary>
	/// Stack data source implementation
	/// </summary>
        public void GetStackResults()
        {
            var client = new StacManClient(key: ConfigurationManager.AppSettings["stackAppKey"], version: "2.1");

            var response = client.Questions.GetAll("stackoverflow",
            page: 1,
            pagesize: 10,
            sort: StackExchange.StacMan.Questions.AllSort.Creation,
            order: Order.Desc,
            filter: "withbody",
            tagged: ConfigurationManager.AppSettings["stackTags"]).Result;

            foreach (var question in response.Data.Items)
            {
                Posts res = new Posts();
                res.Name = question.Owner.DisplayName;
                res.PostText = question.Body;
                res.Category = string.Join(", ", question.Tags);

                //If tags are null, place in General category
                if (res.Category == "" || res.Category == null)
                {
                    res.Category = "General";
                }

                res.Source = "Stack Overflow";
                res.GUID = question.QuestionId.ToString();

                PostResults.Add(res);
            }

        }
```
* Once the function to get the data into the the PostResults list is complete, add it to the DataSources class initialization so that it is called with the existing data source implementations.  
```
public DataSources()
        {
            //Call data source implementations here
            GetTwitterResults();
            GetStackResults();
        }
``` 
* The new data source function should now be getting posts and adding them to the Feed. 

## Deployment

For easy deployment to IIS, use Visual Studio web deploy. 

## Built With

* [oAuthTwitterWrapper](http://www.dropwizard.io/1.0.2/docs/) - Twitter Client
* [StacMan](https://maven.apache.org/) - Stack Client
* [Newtonsoft.Json](https://rometools.github.io/rome/) - Used to parse JSON

## Authors

* **Nick Gamb** -  [Twitter](https://twitter.com/nickcgamb?lang=en)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Thank you to [emmettnicholas](https://github.com/emmettnicholas) for StackMan and [andyhutch77](https://github.com/andyhutch77) for oAuthTwitterWrapper



