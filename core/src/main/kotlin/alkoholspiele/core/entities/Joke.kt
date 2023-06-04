package alkoholspiele.core.entities

import java.util.UUID

class Joke {

    val id: UUID;
    val content: String;

    constructor(id: UUID, content: String) {
        this.id = id
        this.content = content
    }

    constructor(content: String) {
        this.id = UUID.randomUUID()
        this.content = content
    }


}