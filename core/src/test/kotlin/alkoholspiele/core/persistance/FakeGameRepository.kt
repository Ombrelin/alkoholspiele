package alkoholspiele.core.persistance

import alkoholspiele.core.entities.Game
import java.util.*
import kotlin.collections.HashMap

class FakeGameRepository : GameRepository {

    val data: HashMap<UUID, Game> = HashMap();

    override suspend fun insert(game: Game) {
        data[game.id] = game;
    }

    override suspend fun getById(id: UUID): Game? {
        return data[id];
    }
}