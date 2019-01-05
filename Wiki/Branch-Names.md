# Branch Names

With our GitFlow it's important that things are named properly once we get into the development cycle.
There are 3 main folders that we take care of: develop, feature and hotfix.

## Develop

Develop is used when creating a big feature.
So once someone wants to start working on character pages.
We start off with the branch develop/character.
This branch will be taken from the 'dev' branch.
When this branch is fully done with its development it will be merged back into dev using a pull request.

## Feature

This is for working out separate features within one develop.
Sticking with character pages, lets say I want to work out combos.
I would call my branch feature/combos, and I would make it from develop/character.
After I'm done I will make a pull request for my branch (feature/combos) to be merged back into the original branch (develop/character)

## Hotfix

Hotfix is only used when making minor fixes outside of a develop branch.
Hotfixes are pulled from and into the 'dev' branch