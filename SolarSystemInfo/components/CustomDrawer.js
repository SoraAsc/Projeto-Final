import { DrawerContent, DrawerContentScrollView, DrawerItem, DrawerItemList } from '@react-navigation/drawer';
import React from 'react';
import {View, Text, Image} from 'react-native';
import { DrawerActions, DrawerNavigatorItems } from 'react-navigation-drawer';

export default function CustomDrawer({...props}){
    //console.log(props.navigation)
    return(
        <DrawerContentScrollView  {...props}>
            <Image style={{width: 160, height: 160, alignSelf:'center',}} source={require('./../assets/images/saturnoLogo.png')}></Image>
            <DrawerItem label="Bem Vindo!" {...props} labelStyle={{fontFamily: 'Dancing Script', color:'white', 
            fontSize:30, alignSelf:'center'}}/>
            <DrawerItemList {...props}/>
        </DrawerContentScrollView>
        //<View style={{backgroundColor: '#000', flex: 1, alignItems: 'center'}}>
          //  <Image style={{width: 160, height: 160}} source={require('./../assets/images/saturnoLogo.png')}></Image>
            //<Text style={{color: 'white', fontFamily: 'Dancing Script', fontSize:30}}>Bem Vindo!</Text>
            //<DrawerNavigatorItems {...props} />
        //</View>
    )
}