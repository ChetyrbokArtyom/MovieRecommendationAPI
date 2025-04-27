export interface Movie {
  Title: string;
  Year: string;
  imdbID: string;
  Type?: string;
  Poster: string;
  Genre?: string;     
  imdbRating?: string; 
  ShortTitle?: string;
}
  
  export interface ApiResponse {
    Search?: Movie[];
    totalResults?: string;
    Response: string;
    Error?: string;
  }