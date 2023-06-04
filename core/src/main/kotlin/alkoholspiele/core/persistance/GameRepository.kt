package alkoholspiele.core.persistance

import alkoholspiele.core.entities.Game
import java.util.*

interface GameRepository {
    suspend fun insert(game: Game)
    suspend fun getById(id: UUID): Game?
}