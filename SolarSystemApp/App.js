import React from 'react';
import Home from './src/pages/Home';
import Details from './src/pages/Details';
import Header from './components/Header';
import CustomDrawer from './components/CustomDrawer';


import { NavigationContainer } from '@react-navigation/native'
import { createStackNavigator } from '@react-navigation/stack'
import { createDrawerNavigator } from '@react-navigation/drawer'

const Stack = createStackNavigator()
const Drawer = createDrawerNavigator();

function StackNavigator({navigation}){
  return(
    <Stack.Navigator>
      <Stack.Screen 
        name="Home"
        component = {Home}
        options={{
          headerTitle: () => <Header navigation={navigation} />,
          headerStyle:{
            backgroundColor: 'black',
          }
        }}
      />
      <Stack.Screen 
        name="Details"
        component = {Details}        
        options={{
          title: 'Detalhes',
          headerTintColor: 'white',
          headerStyle:{            
            backgroundColor: 'black',
          },
          //headerRight: ()=>(            
            //<Button title="Menu" onPress={() => navigation.toggleDrawer()} />
          //)
        }}
      />
    </Stack.Navigator>
  )
}

function DrawerNavigator() {
  return (
    <Drawer.Navigator    
    drawerContentOptions={
      {
        activeBackgroundColor: 'red',
        
        contentContainerStyle:{          
          backgroundColor: '#000',
          flex: 1,
          
        },
        labelStyle:{
          color: 'white',          
          alignSelf:'center'
        }
      }
    }
    drawerContent={(props) => <CustomDrawer{...props} />}
    >
      <Drawer.Screen name="Home" component={StackNavigator} />
    </Drawer.Navigator>
  );
}

export default function App(){
  return(
    <NavigationContainer>
      <DrawerNavigator/>
    </NavigationContainer>
  )
}


