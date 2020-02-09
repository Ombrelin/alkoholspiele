package fr.arsene.alkoholspiele.model.documents;

import lombok.*;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.util.LinkedList;
import java.util.List;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Document
public class Game {

    @Id
    private String id;

    private String author;
    private String name;

    private List<Joke> jokes;

    public Game(String id, String author, String name) {
        this.id = id;
        this.author = author;
        this.name = name;
        this.jokes = new LinkedList<>();
    }
}
