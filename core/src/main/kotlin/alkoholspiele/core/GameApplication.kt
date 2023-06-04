package alkoholspiele.core

import alkoholspiele.core.contracts.CreateGameRequest
import alkoholspiele.core.contracts.CreateGameResponse
import alkoholspiele.core.persistance.GameRepository

class GameApplication(val gameRepository: GameRepository) {

    suspend fun createGame(request: CreateGameRequest): CreateGameResponse{
        val game = request.toGame()
        gameRepository.insert(game)
        return CreateGameResponse(game)
    }

}