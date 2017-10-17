# StoryMark
## WARNING
If you use this to edit your novel and it somehow deletes your work, that's on you. 
I wrote this for myself and am sharing because people asked me to.

## Description
An opinionated fiction editor. It includes the features I personally want and need. 
It does not and will not contain other features.

## Installation
To set it up how I have it, follow the instructions below.

* Create a database called Storymark
* In the Storymark.Web folder, create a file called Web.config.connectionStrings.secrets.
* In that file, put a connectionstring config section, like the one below, adjusted to
	match your machine and credentials.
	<connectionStrings>
		<add name="DBConnection" connectionString="Data Source=localhost;Initial Catalog=Storymark;Integrated Security=True;Pooling=False" providerName="System.Data.SqlClient" />
	</connectionStrings>
* In the Storymark.Web folder, create a file called Web.config.secrets.
* Get an Auth0 account and api keys. Figuring out exactly which of the keys you need from them
	is a pain, but only has to happen once.
* In that folder, put an appSettings with the Auth0 information in that Web.config.secrets file.
	An example section is in the Web.config, commented out.