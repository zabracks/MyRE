﻿import { Store } from "MyRE/Models/Store";
import { AppAction } from "MyRE/Actions";
import { some, none } from "ts-option";
import { List } from "immutable";
import * as ProjectActions from 'MyRE/Actions/Projects';

export const reduceProjects = (state: Store.Projects, action: AppAction): Store.Projects => {
    let newState = Object.assign({}, state);

    switch (action.type) {
        case 'API_RESPONSE':
            if (action.requestType === 'API_REQUEST_PROJECT_LIST') {
                if (action.response.result === 'success') {
                    newState.projects = some(List(action.response.data.map(p => ({
                        projectId: p.ProjectId,
                        name: p.Name,
                        description: p.Description,
                        instanceId: p.InstanceId,
                        routines: none,
                    }))));
                }
            } else if (action.requestType === 'API_CREATE_NEW_PROJECT') {
                if (action.response.result === "success") {
                    newState.createProjectModalOpen = false;
                    newState.createProjectMessage = none;
                    newState.newProject = { Name: '', Description: '', InstanceId: '' };
                } else {
                    newState.createProjectMessage = some<Store.AlertMessage>({
                        level: 'danger',
                        message: action.response.message.getOrElse(action.response.status.toString()),
                    });
                }
            } else if (action.requestType === 'API_LOGOUT') {
                if (action.response.result === "success") {
                    newState.projects = none;
                }
            } else if (action.requestType === 'API_ATTEMPT_LOGIN') {
                if (action.response.result === "success") {
                    newState.projects = none;
                } else {
                    newState.projects = some(List([]));
                }
            } else if (action.requestType === 'API_LIST_PROJECT_ROUTINES') {
                if (action.response.result === 'success') {
                    let response = action.response;
                    newState.projects = some(List(state.projects.getOrElse(List([])).map(p => {
                        if (p.projectId === action.requestAction.projectId) {
                            let newProject = Object.assign({}, p);
                            newProject.routines = some(response.data.map((r): Store.Routine => ({
                                routineId: r.RoutineId,
                                projectId: r.ProjectId,
                                name: r.Name,
                                description: r.Description,
                                block: none,
                            })).toList());
                        } 
                        return p;
                    })))
                }
            }
            return newState;
            
        case 'UI_TOGGLE_CREATE_PROJECT_DIALOG':
            if (state.createProjectModalOpen) {
                // Close the modal and clear out state data.
                newState.createProjectModalOpen = false;
                newState.newProject = { Name: '', Description: '', InstanceId: '' };
            } else {
                newState.createProjectModalOpen = true;
            }
            return newState;

        case 'UI_CHANGE_NEW_PROJECT_DATA':
            newState.newProject = action.value;
            return newState;

        case 'API_CREATE_NEW_PROJECT':
            newState.createProjectMessage = none;
            return newState;
            
        default:
            return state;
    }
}