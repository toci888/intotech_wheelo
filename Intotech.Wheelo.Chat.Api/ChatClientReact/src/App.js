import WheeloClient from './wheelo/engine/WheeloClient';


import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

const App = () => {
 
  const wheeloClient = new WheeloClient();

  var renderMsg = (user, msg) => {

    document.getElementById('chatBox').innerHTML += '<div>' + msg + '<span style="color:green;">' + user + '</span></div>';
  }

 // WheeloClient.joinRoom("wheelo");
 
//console.log('dafaq');
  //  
//  const gooovno = () => { wheeloClient.joinRoomClient('doopa'); }

//onClick={() => wheeloClient.joinRoomClient('doopa')}

  return <div className='app'>
  <h2>Wheelo Chat</h2>
  <hr className='line' />
  message: <input type="text" id="messId"></input>
  user Id: <input type="text" id="userId"></input>
  user Name: <input type="text" id="userName"></input>
  invited user Id: <input type="text" id="userIdInv"></input>
  invited user Name: <input type="text" id="userNameInv"></input>
  <div id="chatBox"></div>
  <input type="submit" onClick={() => wheeloClient.chat('WheeloHeroes', "Julia", 
    document.getElementById("messId").value, document.getElementById("userId").value, "1234", renderMsg)}></input>
  <input type="submit" value="Connect" onClick={() => wheeloClient.connect(document.getElementById("userId").value, document.getElementById("userName").value)}></input>
  <input type="submit" value="Invite" onClick={() => 
    wheeloClient.requestConversation(document.getElementById("userId").value, document.getElementById("userName").value, 
    document.getElementById("userIdInv").value, document.getElementById("userNameInv").value)}></input>
  
</div>
  
}

export default App;


/*
 const [connection, setConnection] = useState();
  const [messages, setMessages] = useState([]);
  const [users, setUsers] = useState([]);

  const joinRoom = async (room) => {
    try {
      const connection = new HubConnectionBuilder()
        .withUrl("https://localhost:7082/wheeloChat")
        .configureLogging(LogLevel.Information)
        .build();

      connection.on("ReceiveMessage", (user, message) => {
        console.log("lol" + user, "lol" + message);
        setMessages(messages => [...messages, { user, message }]);
      });

      connection.on("UsersInRoom", (users) => {
        setUsers(users);
      });

      connection.onclose(e => {
        setConnection();
        setMessages([]);
        setUsers([]);
      });

      await connection.start();
      
      await connection.invoke("JoinRoom", room);
      setConnection(connection);

      //await sendMessage("Hi From Wheelo!", "GhostRider", "wheelo");

      //connection.invoke("SendMessage", "Hi From Wheelo!", "GhostRider");

      //setTimeout(sendMessage("Hi From Wheelo!", "GhostRider"), 4000);
    } catch (e) {
      console.log("KURWA !!!!!!!!!!", e);
    }
  }

  const sendMessage = async (message, user, room) => {
    try {
      console.log(message, user, connection, room);
      await connection.invoke("SendMessage", message, "John", "wheelo");
    } catch (e) {
      console.log(e);
    }
  }

  const closeConnection = async () => {
    try {
      await connection.stop();
    } catch (e) {
      console.log(e);
    }
  }

  joinRoom("wheelo");
  */