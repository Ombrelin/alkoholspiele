package alkoholspiele.core.entities

import java.util.UUID

class Game {
    val id: UUID
    val name: String;
    val author: String;
    val jokes: List<Joke>;

    constructor(name: String, author: String, jokes: List<Joke>) {
        this.name = name;
        this.author = author;
        id = UUID.randomUUID();
        this.jokes = jokes
    }

    constructor(id: UUID, name: String, author: String, jokes: List<Joke>) {
        this.name = name;
        this.author = author;
        this.id = id;
        this.jokes = jokes
    }


}