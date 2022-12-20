import Auth from "./pages/Auth"
import Feed from "./pages/Feed"
import Home from "./pages/Home"
import Post from "./pages/Post"
import Subs from "./pages/Subs"
import User from "./pages/User"
import { AUTH_ROUTE, FEED_ROUTE, HOME_ROUTE, POST_ROUTE, REG_ROUTE, SUBS_ROUTE, SUB_ROUTE, USER_ROUTE } from "./utils/consts"

export const authRoutes = [
    {
        path: FEED_ROUTE,
        Component: Feed
    },
    {
        path: POST_ROUTE + '/:id',
        Component: Post
    },
    {
        path: USER_ROUTE + '/:id',
        Component: User
    },
    {
        path: SUBS_ROUTE,
        Component: Subs
    },
    {
        path: SUB_ROUTE,
        Component: Subs
    }
]

export const publicRoutes = [
    {
        path: AUTH_ROUTE,
        Component: Auth
    },
    {
        path: REG_ROUTE,
        Component: Auth
    },
    {
        path: HOME_ROUTE,
        Component: Home
    }
]