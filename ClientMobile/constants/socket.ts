import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

import { endpoints } from "./constants";

const token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImJhcnRla0BnZy5wbCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJTdGVmYW5pYSBEemlld3Vsc2tpIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiVXNlciIsImV4cCI6MTY3MzYzMTQ0OSwiaXNzIjoiaHR0cDovL2ludG90ZWNoLmNvbS5wbCIsImF1ZCI6Imh0dHA6Ly9pbnRvdGVjaC5jb20ucGwifQ.co-CSfDlsdq4EHHtskho6Y7ixdBC15ItFxxcZIbwbfA';
export const socket = new HubConnectionBuilder()
    .withUrl(endpoints.chat
        , { accessTokenFactory: () => token }
    )
    .configureLogging(LogLevel.Information)
    .withAutomaticReconnect()
    .build();

// connect user: session: data=> name, surname, userID, sessionID

// export const makeHubConnection = (accessToken: string): HubConnection => {
//     return new HubConnectionBuilder()
//     .withUrl(endpoints.chat, {
//       // transport: HttpTransportType.WebSockets,
//       accessTokenFactory: () => accessToken,
//       logMessageContent: true
//     })
//     .configureLogging(LogLevel.Information)
//     // .configureLogging({
//     //   log: function (logLevel, message) {
//     //     // TODO: Remove after finish testing
//     //     // console.log('SIGNALR: ' + new Date().toISOString() + ': ' + message)
//     //   }
//     // })
//     .build()
//   }