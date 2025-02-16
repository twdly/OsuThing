# osu!thing
A score comparison and viewer tool written with Blazor for osu!

## Setup
1. Create an osu! account [here](https://osu.ppy.sh) if you do not already have one
2. Go to the [account settings page](https://osu.ppy.sh/home/account/edit) and scroll down to the OAuth section
3. Add a new OAuth application with any name and no callback URLs
4. Create a file called `apikey` inside of the OsuThing directory (i.e. in the same directory as `OsuThing.csproj`)
5. Put the Client ID from your OAuth application on the first line of `apikey` and the Client Secret on the second line
6. The project is now ready to use