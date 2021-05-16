import { DrawerContentScrollView, DrawerItem, DrawerItemList } from '@react-navigation/drawer';
import React from 'react';
import {Image} from 'react-native';

export default function CustomDrawer({...props}){
    //console.log(props.navigation)
    return(
        <DrawerContentScrollView  {...props}>
            <Image style={{width: 160, height: 160, alignSelf:'center',}} source={require('./../assets/images/saturnoLogo.png')}></Image>
            <DrawerItem label="Bem Vindo!" {...props} labelStyle={{fontFamily: 'Dancing Script', color:'white', 
            fontSize:30, alignSelf:'center'}}/>
            <DrawerItemList {...props}/>
        </DrawerContentScrollView>
    )
}