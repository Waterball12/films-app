import React, {ChangeEvent, useState} from 'react';
import {
    AppBar,
    Button,
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
    Grid,
    TextField,
    Toolbar,
    Typography
} from "@material-ui/core";
import {makeStyles} from "@material-ui/core/styles";
import Alert from '@material-ui/lab/Alert';
import {useAuth} from "./Auth";
import {Link} from "react-router-dom";

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
    },
    menuButton: {
        marginRight: theme.spacing(2),
    },
    title: {
        flexGrow: 1,
        textDecoration: 'unset',
        color: '#fff'
    },
}));

const Header = () => {
    const classes = useStyles();
    const [open, setOpen] = useState<boolean>(false);
    const [username, setUsername] = useState<string>('example');
    const [password, setPassword] = useState<string>('pass')

    const {setToken, token} = useAuth();

    const handleClose = () => {
        setOpen(false);
    }

    const handleOpen = () => {
        setOpen(true);
    }
    const login = () => {
        fetch('https://localhost:5001/api/user/sign-in', {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json'
            },
            redirect: 'follow',
            referrerPolicy: 'no-referrer',
            body: JSON.stringify({username: username, password: password})
        })
            .then(rsp => rsp.json())
            .then((data: any) => {
                setToken(data.bearerToken);
                setOpen(false);
            });
    }

    const logout = () => {
        fetch('https://localhost:5001/api/user/sign-out', {
            method: 'POST',
            mode: 'cors',
            cache: 'no-cache',
            credentials: 'same-origin',
            headers: {
                'Content-Type': 'application/json'
            },
            redirect: 'follow',
            referrerPolicy: 'no-referrer',
            body: JSON.stringify({username: username, password: password})
        })
            .then(() => {
                setToken(null);
            });
    }

    const handlePasswordChange = (event: ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
    }

    const handleUsernameChange = (event: ChangeEvent<HTMLInputElement>) => {
        setUsername(event.target.value);
    }

    return (
        <>
            <AppBar position="static">
                <Toolbar>
                    <Typography variant="h6" className={classes.title} component={Link} to="/">
                        Films
                    </Typography>
                    <Button color="inherit" onClick={handleOpen}>Login</Button>
                </Toolbar>
            </AppBar>
            <Dialog maxWidth="xs" fullWidth onClose={handleClose} open={open}>
                <DialogTitle>Login</DialogTitle>
                <DialogContent>
                    <Alert severity="info">Username: <b>example</b> password: <b>pass</b></Alert>
                    <Grid>
                        <Grid item>
                            <Typography variant="subtitle1">Username</Typography>
                            <TextField value={username} fullWidth onChange={handleUsernameChange} />
                        </Grid>
                        <Grid item>
                            <Typography variant="subtitle1">Password</Typography>
                            <TextField value={password} type="password" fullWidth onChange={handlePasswordChange} />
                        </Grid>
                    </Grid>
                </DialogContent>
                <DialogActions>
                    <Button onClick={handleClose}>
                        Cancel
                    </Button>
                    {token != null ? (
                        <Button onClick={logout}>
                            Log Out
                        </Button>
                    ) : (
                        <Button onClick={login}>
                            Login
                        </Button>
                    )}

                </DialogActions>
            </Dialog>
        </>
    );
};

export default Header;