package alkoholspiele.core

import alkoholspiele.core.contracts.CreateGameRequest
import alkoholspiele.core.persistance.FakeGameRepository
import org.junit.jupiter.api.Assertions.assertEquals
import org.junit.jupiter.api.Assertions.assertNotNull
import org.junit.jupiter.api.Test
import kotlinx.coroutines.*

class GameApplicationTests {

    private val fakeGameRepository = FakeGameRepository()
    private val target = GameApplication(fakeGameRepository)

    @Test
    fun createGame_insertsGame() = runBlocking {
        // Given
        val request = CreateGameRequest("Test Game", "John Shepard")

        // When
        val response = target.createGame(request)

        // Then
        assertNotNull(response.id)
        assertEquals(request.name, response.name)
        assertEquals(request.author, response.author)

        val gameInDb = fakeGameRepository.data[response.id]
        assertNotNull(gameInDb)
        assertEquals(request.name, gameInDb!!.name)
        assertEquals(request.author, gameInDb.author)

    }

}