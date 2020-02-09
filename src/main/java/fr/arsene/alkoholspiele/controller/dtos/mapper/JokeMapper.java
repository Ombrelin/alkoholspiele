package fr.arsene.alkoholspiele.controller.dtos.mapper;

import fr.arsene.alkoholspiele.controller.dtos.JokeDTO;
import fr.arsene.alkoholspiele.model.documents.Joke;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface JokeMapper {
    JokeDTO jokeToDto(Joke dto);

    Joke dtoToJoke(JokeDTO dto);

}
