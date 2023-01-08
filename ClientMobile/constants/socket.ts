import { HubConnectionBuilder } from "@microsoft/signalr";
import { io } from "socket.io-client";

import { endpoints } from "./constants";

export const socket = new HubConnectionBuilder().withUrl(endpoints.chat).build();
