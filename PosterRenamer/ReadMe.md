# PosterRenamer

PosterRenamer is a tool to create a copy of movie poster for Kodi scraper to pick up.

If you have scrape a movie and save the movie poster images in the movie folder, but Kodi doesn't pick it up when scraping, this tool can help. This tool will create copies of movie poster with these names :

1. *movie*.jpg
1. *movie*-poster.jpg
1. folder.jpg
1. poster.jpg
1. *movie*.png
1. *movie*-poster.png
1. folder.png
1. poster.png

## Installation

Copy the content to the parent folder that you want process. For example, I have a Movie folder which contain a lot of movie subfolder. I put PosterRenamer at Movie folder

Movie

-Assassins (2014)

-Avenger (1990)

-*other movie folder*

## Usage

Run dotnet core executable. (There is no exe. Its .Net Core.)

```bash
dotnet PosterRenamer.dll
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.
