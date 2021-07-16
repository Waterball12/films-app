import React, {useEffect, useState} from 'react';
import {Box, Button, Card, CardActions, CardContent, Container, Grid, Typography} from "@material-ui/core";
import CssBaseline from '@material-ui/core/CssBaseline';
import {Film} from "../types/Film";
import FilmCard from "../components/FilmCard";
import Header from "../components/Header";
import {FilmWatched} from "../types/FilmWatched";
import {useAuth} from "../components/Auth";


const Homepage = () => {
    const [films, setFilms] = useState<Film[]>([]);
    const [watchedFilms, setWatched] = useState<FilmWatched[]>([]);

    const {token} = useAuth();

    useEffect(() => {
        fetch('https://localhost:5001/api/film')
            .then(response => response.json())
            .then((data: Film[]) => setFilms(data))
            .catch(error => {
                console.log(error);
            });
    }, []);

    useEffect(() => {
        if (token != null) {
            fetch('https://localhost:5001/api/filmWatched', {
                headers: {'Authorization': `Bearer ${token}`}
            })
                .then(rsp => rsp.json())
                .then(data => {
                    setWatched(data);
                })
        }
    }, [token]);

    const handleWatchAdd = (id: number ) => {
        fetch('https://localhost:5001/api/filmWatched', {
            method: "POST",
            headers: {'Authorization': `Bearer ${token}`, 'Content-Type': 'application/json'},
            body: JSON.stringify({filmId: id})
        })
            .then(rsp => rsp.json())
            .then(data => {
                setWatched(prev => [...prev, {...data}]);
            })
    }

    const handleWatchRemove = (id: number ) => {
        fetch('https://localhost:5001/api/filmWatched', {
            method: "DELETE",
            headers: {'Authorization': `Bearer ${token}`, 'Content-Type': 'application/json'},
            body: JSON.stringify({id: id})
        })
            .then(rsp => rsp.json())
            .then(data => {
                setWatched(watchedFilms.filter(x => x.id != data.id));
            })
    }

    return (
        <>
            <Header />
            <Box component="main" py={2}>
                <Container>
                    <Box mt={2}>
                        <Typography variant="h3" color="textPrimary" component="h1">
                            Catalogue
                        </Typography>
                        <Grid container justifyContent="flex-start" wrap={"wrap"} spacing={2}>
                            {films.filter(x => !watchedFilms.some(y => y.filmId == x.id)).map((film, key) => (
                                <Grid key={key} item xs={12} sm={4} md={2}>
                                    <FilmCard
                                        id={film.id}
                                        name={film.name}
                                        rating={film.rating}
                                        release={film.release}
                                        onWatched={handleWatchAdd}
                                    />
                                </Grid>
                            ))}
                        </Grid>
                    </Box>
                    {token != null && (
                        <Box mt={4}>
                            <Typography variant="h3" color="textPrimary" component="h1">
                                Watched films
                            </Typography>
                            <Grid container justifyContent="flex-start" wrap={"wrap"} spacing={2}>
                                {watchedFilms.map((film, key) => (
                                    <Grid key={key} item xs={12} sm={4} md={2}>
                                        <Card>
                                            <CardContent>
                                                {films.filter(x => x.id == film.filmId)[0]?.name}
                                            </CardContent>
                                            <CardActions>
                                                <Button onClick={() => {
                                                    handleWatchRemove(film.id);
                                                }}>
                                                    Remove
                                                </Button>
                                            </CardActions>
                                        </Card>
                                    </Grid>
                                ))}
                            </Grid>
                        </Box>
                    )}
                </Container>
            </Box>
            <CssBaseline />
        </>
    );
};

export default Homepage;