package fr.arsene.alkoholspiele.controller.dtos.mapper;

import fr.arsene.alkoholspiele.controller.dtos.GameDTO;
import fr.arsene.alkoholspiele.model.documents.Game;
import org.mapstruct.Mapper;

@Mapper(componentModel = "spring")
public interface GameMapper {

    GameDTO gameToDto(Game dto);

    Game dtoToGame(GameDTO dto);

}
