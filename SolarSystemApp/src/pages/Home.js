import React from 'react';
import {
  StyleSheet,
  Image,
  View,
  FlatList,
} from 'react-native';


import Data from './../data/Database'

import TopicItem from './../../components/TopicItem';

  export default function App(props){
    return(

      <View style={styles.container}>
        <View style={styles.holderMainTopic}>
          <Image style={styles.mainTopLogo}
            source= {require('./../../assets/images/logov3.jpg')}
          ></Image>
        </View>
        <View style={styles.holderPlanetInfo}>
          <FlatList
            data={Data}
            keyExtractor={ item=> item.id}
            showsVerticalScrollIndicator={false}
            renderItem = {({item}) =>(
              <TopicItem item={item} navigation= {props.navigation}/>
            )}
          >
          </FlatList>
        </View>
      </View>
    )
  }
  
  const styles = StyleSheet.create({
    container: {
      flex: 1,
      backgroundColor:'red',
      flexDirection: 'column',
    },
    holderMainTopic: {
      backgroundColor: 'blue',
      flex: 0.5,
    },
    mainTopLogo: {
      width: '100%',
      height: '100%',    
      flexGrow: 1,      
    },
    holderPlanetInfo: {
      backgroundColor: 'green',
      flex: 0.5,
    },
  
  });
  
  