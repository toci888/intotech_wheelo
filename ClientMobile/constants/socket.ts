import { HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { Author } from "../types/conversation";

import { endpoints } from "./constants";

export const createSocket = (token: string) => {
    socket = new HubConnectionBuilder()
        .withUrl(endpoints.chat, { accessTokenFactory: () => token })
        .configureLogging(LogLevel.Information)
        .withAutomaticReconnect()
        .build();
}

export let socket: HubConnection;

export const connectUser = async (id: number) => {
    await socket.invoke("connectUser", id);
}

export const sendMessage = async (
    author: Author,
    roomId: string,
    text: string,
  ) => {
    await socket.invoke("sendMessage", {
        author,
        roomId,
        text,
    });
}

export const joinRoom = async (roomId: string) => {
    await socket.invoke("joinRoom", roomId);
}

export const createRoom = async (userId: number, accountIds: number[]) => {
    await socket.invoke("createRoom", userId, accountIds);
}
