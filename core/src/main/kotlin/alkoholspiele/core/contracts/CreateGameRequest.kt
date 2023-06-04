package alkoholspiele.core.contracts

import alkoholspiele.core.entities.Game

data class CreateGameRequest(val name: String, val author: String) {
    fun toGame(): Game {
        return Game(name, author, listOf());
    }
}