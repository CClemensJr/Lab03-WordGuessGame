# guess the word
>its like hangman without the hanging!

## summary
```
	Josie Cat has requested that a “Word Guess Game” be built. The main idea of the game is she must guess what a mystery word is by inputting (1) letter at 
	a time. The game should save all of her guesses (both correct and incorrect) throughout each session of the game, along with the ability to show her how 
	many letters out of the word she has guessed correctly.
	
	Each time a new game session starts, the mystery word chosen should come from an external text file that randomly selects one of the words listed. 
	This bank of words should be editable by Josie so that she may view, add, and delete words as she wishes. She expects the game to have a simple user
	interface that is easy to navigate.
```

# example

mystery word:

``` 
	mystery word: _ _ _
```

guess:

```
	guess a letter: a
```

correct guess output:

```diff
	+ mystery word: _ a _
```

incorrect guess output:

```diff
	mystery word: _ _ _
	- guesses: a
```

## usage
```
	1. Use the number of blank spaces to think of a word that may fit.
	2. Enter a letter.
	3. If the letter is in the word then it will replace a previously blank space. Congrats!
	4. Repeat this process until the spaces have been filled and the word revealed!
```

## installation
```
	1. Click on green "Clone or download" button.
	2. Click on the clipboard.
	3. Clone the repository to your projects folder.
	4. Open the project in Visual Studio
	5. Run the application
```

## author

* **Charles Clemens** - *Initial work* - [CClemensJr](https://github.com/CClemensJr)


## license
```
	This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
```