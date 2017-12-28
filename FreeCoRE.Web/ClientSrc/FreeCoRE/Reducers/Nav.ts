﻿import { AppAction } from "FreeCoRE/Actions";
import { Store } from "FreeCoRE/Models/Store";

export const reduceNav = (state: Store.Nav, action: AppAction): Store.Nav => {
    switch (action.type) {
        case 'NAV_PANE_OPEN':
            return { navPaneOpen: true };
        case 'NAV_PANE_CLOSE':
            return { navPaneOpen: false };
        default:
            return state;
    }
}