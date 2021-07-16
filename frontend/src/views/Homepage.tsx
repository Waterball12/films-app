import React, {useEffect, useState} from 'react';
import {Box, Container, Grid, Typography} from "@material-ui/core";
import CssBaseline from '@material-ui/core/CssBaseline';
import {Film} from "../types/Film";
import FilmCard from "../components/FilmCard";
import Header from "../components/Header";
import {FilmWatched} from "../types/FilmWatched";


const Homepage = () => {
    const [films, setFilms] = useState<Film[]>([]);
    const [watchedFilms, setWatched] = useState<FilmWatched[]>([]);

    useEffect(() => {
        fetch('https://localhost:5001/api/film')
            .then(response => response.json())
            .then((data: Film[]) => setFilms(data))
            .catch(error => {
                console.log(error);
            });
    }, []);

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
                            {films.map((film, key) => (
                                <Grid key={key} item xs={12} sm={4} md={2}>
                                    <FilmCard id={film.id} name={film.name} rating={film.rating} release={film.release} />
                                </Grid>
                            ))}
                        </Grid>
                    </Box>
                    <Box mt={4}>
                        <Typography variant="h3" color="textPrimary" component="h1">
                            Watched films
                        </Typography>
                        <Grid container justifyContent="flex-start" wrap={"wrap"} spacing={2}>
                            {watchedFilms.map((film, key) => (
                                <div>ffw</div>
                            ))}
                        </Grid>
                    </Box>
                </Container>
            </Box>
            <CssBaseline />
        </>
    );
};

export default Homepage;