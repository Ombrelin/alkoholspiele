import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

export class Joke {
  constructor(
    public id?: string,
    public author?: string,
    public content?: string,
    public number?: number
  ) {
  }
}

export class Game {
  constructor(
    public id: string,
    public author: string,
    public name: string,
    public jokes: Array<Joke>
  ) {
  }
}

@Injectable({
  providedIn: 'root'
})
export class GameServiceService {

  private api = 'https://alkoholspiele.arsenelapostolet.fr/api/';
  //private api = 'https://localhost:5001/api/';
  constructor(
    private httpClient: HttpClient
  ) {
  }

  createGame(author: string, name: string) {
    const dto = {
      author: author,
      name: name
    };
    return this.httpClient.post<Game>(`${this.api}Games`, dto);
  }

  getGame(id: string) {
    return this.httpClient.get<Game>(`${this.api}Games/${id}`);
  }

  addJoke(gameId: string, author: string, content: string, number: number) {
    const dto = {
      author: author,
      content: content,
      number: number
    };

    return this.httpClient.post(`${this.api}Games/${gameId}`, dto);
  }
}
