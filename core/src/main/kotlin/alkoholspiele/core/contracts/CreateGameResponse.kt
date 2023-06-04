package alkoholspiele.core.contracts

import alkoholspiele.core.entities.Game
import java.util.UUID

class CreateGameResponse (val id: UUID, val name: String, val author: String){


    constructor(game: Game) : this(game.id, game.name, game.author) {
    }

}