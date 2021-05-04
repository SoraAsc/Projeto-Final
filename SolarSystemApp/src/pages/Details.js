import React, { Component } from 'react';
import {
  StyleSheet,
  Text,
  Image,
  View,
  ScrollView,
} from 'react-native';

import { useNavigation, useNavigationState } from '@react-navigation/native'

export default function Details(props){
    console.log(props.route.params.data.imageLink)
    return (
        <View style={styles.container}>
          <View style={{flex: 0.5}}>
            <Image style={styles.itemimage} source={props.route.params.data.imageLink}>                
            </Image>
          </View>
          <View style={{flex:0.5}}>
            <ScrollView>
            <Text style={{color:'white'}}>
              Ex aliqua fugiat labore mollit minim fugiat laboris sunt id magna tempor anim dolore consectetur. Reprehenderit pariatur eu exercitation deserunt non ut ea. Culpa cupidatat aliqua duis deserunt et et irure reprehenderit qui velit magna adipisicing occaecat pariatur.

              Duis esse officia velit sunt sit cillum irure qui Lorem. Esse consectetur pariatur labore ea occaecat proident ex ipsum esse consequat commodo ad proident. Ex qui nulla nulla sunt aliqua. Consequat aliquip nisi non amet dolore ut. Exercitation officia cillum in eu veniam laborum eiusmod ipsum. Dolore anim labore aute culpa.

              Magna consequat esse enim laboris labore proident consequat labore sit incididunt ea et. Adipisicing sunt qui sunt ullamco velit. Eu ea reprehenderit laborum nulla elit aliquip culpa do eu culpa irure. Laboris consectetur nostrud et sunt. Veniam non officia Lorem est tempor.
              Ex aliqua fugiat labore mollit minim fugiat laboris sunt id magna tempor anim dolore consectetur. Reprehenderit pariatur eu exercitation deserunt non ut ea. Culpa cupidatat aliqua duis deserunt et et irure reprehenderit qui velit magna adipisicing occaecat pariatur.

              </Text>
            </ScrollView>
          </View>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor:'red',
      flexDirection: 'column',
      backgroundColor: 'black',
    },
    itemimage: {
      width:'100%',
      height: 200,
      flexGrow: 1,
      opacity: 0.9,
      borderRadius: 40,
      borderTopLeftRadius: 0,
      borderTopRightRadius: 0,
    },

  });
