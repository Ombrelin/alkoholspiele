package fr.arsene.alkoholspiele.model.repositories;

import fr.arsene.alkoholspiele.model.documents.Game;
import org.springframework.data.mongodb.repository.ReactiveMongoRepository;

public interface GameRepository extends ReactiveMongoRepository<Game,String> {
}
